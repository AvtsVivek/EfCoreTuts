using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ef000302_PieBakeryConsole;

public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
  }
}
