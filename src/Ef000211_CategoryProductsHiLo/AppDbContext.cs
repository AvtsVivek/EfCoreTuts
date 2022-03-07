using Microsoft.EntityFrameworkCore;

namespace Ef000211_CategoryProductsHiLo;

public class AppDbContext : DbContext
{
  public DbSet<Category> Categories { get; set; } = default!;
  public DbSet<Product> Products { get; set; } = default!;
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {

  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.HasSequence<int>("categoryseq").StartsAt(10).IncrementsBy(5);
    modelBuilder.HasSequence<int>("productseq").StartsAt(10).IncrementsBy(10);

    modelBuilder.Entity<Category>(builder =>
    {
      builder
                  .HasMany(x => x.Products)
                  .WithOne()
                  .HasForeignKey(x => x.CategoryId);

      builder
              .Property(x => x.Id)
              .UseHiLo("categoryseq");
    });

    modelBuilder.Entity<Product>(builder =>
    {
      builder
              .Property(x => x.Id)
              .UseHiLo("productseq");
    });
  }
}
