using Microsoft.EntityFrameworkCore;

namespace Ef010101_QueryFilters;

public class ParentDependentDbContext : DbContext
{
  public ParentDependentDbContext(DbContextOptions<ParentDependentDbContext> options)
      : base(options)
  {
  }

  public DbSet<Principal> Principals { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Dependent>()
        .HasQueryFilter(x => !x.SoftDeleted);

    modelBuilder.Entity<Dependent>()
        .HasIndex(x => x.SoftDeleted);
  }
}
