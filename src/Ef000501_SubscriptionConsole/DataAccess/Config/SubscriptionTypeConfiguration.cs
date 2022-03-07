using Ef000501_SubscriptionConsole.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ef000501_SubscriptionConsole.DataAccess.Config;

public class SubscriptionTypeConfiguration : IEntityTypeConfiguration<Subscription>
{
  public void Configure(EntityTypeBuilder<Subscription> builder)
  {
    builder.ToTable("Subscription");
    builder.HasKey(x => x.Id);
    builder.Property(x => x.Id)
        .HasColumnName("SubscriptionID")
        .ValueGeneratedNever();
    builder.Property(x => x.Status)
        .HasConversion(new EnumToStringConverter<SubscriptionStatus>())
        .IsRequired();
    builder.Property(x => x.Amount)
        .HasColumnType("money")
        .IsRequired();
    builder.Property(x => x.CurrentPeriodEndDate)
        .HasColumnType("date")
        .IsRequired();
    builder.HasOne(x => x.Product)
        .WithMany()
        .IsRequired();
    builder.HasOne(x => x.Customer)
        .WithMany(x => x.Subscriptions)
        .IsRequired();
  }
}
