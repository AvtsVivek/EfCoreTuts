using Ef000501_SubscriptionConsole.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ef000501_SubscriptionConsole.DataAccess.Config;

public class TagTypeConfiguration : IEntityTypeConfiguration<Tag>
{
  public void Configure(EntityTypeBuilder<Tag> builder)
  {
    builder.ToTable("Tag");
    builder.HasKey(x => x.Id);
    builder.Property(x => x.Id)
        .HasColumnName("TagID")
        .ValueGeneratedNever();

    builder.Property(x => x.Name)
        .IsRequired();
  }
}

//https://github.com/dotnet/efcore/issues/11162
// ValueGeneratedNever();
