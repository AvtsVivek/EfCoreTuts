using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ef000301_RecordsConsole;

internal class PieEntityTypeConfiguration : IEntityTypeConfiguration<Pie>
{
  public void Configure(EntityTypeBuilder<Pie> builder)
  {

    builder.Property(x => x.Description).HasMaxLength(2500);

    builder.OwnsOne(x => x.ServingSize);

    //builder.Property(x => x.ServingSize).HasConversion(
    //    input => JsonConvert.SerializeObject(input),
    //    output => JsonConvert.SerializeObject(output)
    //    );

  }
}
