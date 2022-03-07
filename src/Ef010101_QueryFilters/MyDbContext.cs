using Microsoft.EntityFrameworkCore;

namespace Ef010101_QueryFilters;

public class MyDbContext : DbContext
{
  public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
  {  }

  public DbSet<MyEntity> MyEntities { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<MyEntity>()
        .HasQueryFilter(x => !x.SoftDeleted);

    modelBuilder.Entity<MyEntity>()
        .HasIndex(x => x.SoftDeleted);
  }
}
