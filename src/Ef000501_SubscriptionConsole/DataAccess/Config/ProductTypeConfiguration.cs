using Ef000501_SubscriptionConsole.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ef000501_SubscriptionConsole.DataAccess.Config;

public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    builder.ToTable("Product");
    builder.HasKey(x => x.Id);
    builder.Property(x => x.Id)
        .HasColumnName("ProductID")
        .ValueGeneratedNever();
    builder.Property(x => x.Name).IsRequired();
    builder.Property(p => p.Amount)
        .IsRequired()
        .HasColumnName("Amount")
        .HasColumnType("money");
    builder.Property(x => x.BillingPeriod)
        .IsRequired()
        .HasColumnName("BillingPeriod")
        .HasConversion(period => period.Name,
            name => BillingPeriod.FromName(name, true));
    builder.HasMany(x => x.Tags)
        .WithMany(x => x.Products);
  }
}

//https://github.com/dotnet/efcore/issues/11162
// ValueGeneratedNever();
