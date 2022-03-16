using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ef000303_PieBakeryConsole;

internal class PieEntityTypeConfiguration : IEntityTypeConfiguration<Pie>
{
  public void Configure(EntityTypeBuilder<Pie> builder)
  {
    builder.Property(x => x.Id).HasField("_id");

    builder.Property(x => x.Name).HasField("_name");

    // Mark the ingredients as an owned collection.
    // And set a backing field for it.
    // var ingredientsConfiguration = builder.OwnsMany(x => x.Ingredients);


    var ingredientsConfiguration = builder.OwnsMany(i => i.Ingredients, b =>
    {
      b.HasKey("PieId", "Id");
      b.Property(b => b.Id).ValueGeneratedNever();
              //b.Property(b => b.Id).ValueGeneratedOnAdd();
    });

    builder.Navigation(x => x.Ingredients).Metadata.SetField("_ingredients");

    // You can configure the rules for owned entities using the returned configuration builder instance.
    ingredientsConfiguration.Property(x => x.Name).HasMaxLength(250).IsRequired();





  }
}
