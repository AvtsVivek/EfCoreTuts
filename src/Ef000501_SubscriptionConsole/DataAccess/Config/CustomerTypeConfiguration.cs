using Ef000501_SubscriptionConsole.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ef000501_SubscriptionConsole.DataAccess.Config;

public class CustomerTypeConfiguration : IEntityTypeConfiguration<Customer>
{
  public void Configure(EntityTypeBuilder<Customer> builder)
  {
    builder.ToTable("Customer");
    builder.HasKey(x => x.Id);
    builder.Property(x => x.Id)
        .HasColumnName("CustomerID")
        .ValueGeneratedNever();
    builder.OwnsOne(x => x.CustomerName, nameBuilder =>
    {
      nameBuilder.Property(p => p.FirstName).HasColumnName("FirstName").IsRequired();
      nameBuilder.Property(p => p.LastName).HasColumnName("LastName").IsRequired();
    });
    builder.Navigation(e => e.CustomerName).IsRequired();

    builder.Property(x => x.Email)
        .HasColumnName("Email")
        .HasConversion(email => email.Value, value => new Email(value))
        .IsRequired();
    builder.Property(p => p.MoneySpent)
        .HasColumnType("money");
  }
}

//https://github.com/dotnet/efcore/issues/11162
// ValueGeneratedNever();
