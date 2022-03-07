using Microsoft.EntityFrameworkCore;

namespace Ef000303_PieBakeryConsole;

public class BakeryDbContext : DbContext
{
  public BakeryDbContext(DbContextOptions<BakeryDbContext> options) : base(options)
  {

  }

  public DbSet<Pie> Pies { get; set; } = default!;
  //public DbSet<Category> Categories { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfiguration(new PieEntityTypeConfiguration());
    //modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());

    //modelBuilder.Entity<Pie>().OwnsMany(i => i.Ingredients, b =>
    //{
    //    b.HasKey("PieId", "Id");
    //    b.Property(b => b.Id).ValueGeneratedNever();
    //});

  }
}
