using Microsoft.EntityFrameworkCore;

namespace Ef010101_QueryFilters;

public class SingleEntityContext : DbContext
{
  public SingleEntityContext(DbContextOptions<SingleEntityContext> options) : base(options)
  {  }

  public DbSet<SingleEntity> MyEntities { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<SingleEntity>()
        .HasQueryFilter(x => !x.SoftDeleted);

    modelBuilder.Entity<SingleEntity>()
        .HasIndex(x => x.SoftDeleted);
  }
}
