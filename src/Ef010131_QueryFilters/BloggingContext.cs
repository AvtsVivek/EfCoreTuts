namespace Ef010131_QueryFilters;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class BloggingContext : DbContext
{
  private readonly string _tenantId;
  private readonly string _directoryPath;

  public BloggingContext(string tenant, string directoryPath)
  {
    _tenantId = tenant;
    _directoryPath = directoryPath;
  }

  public DbSet<Blog> Blogs { get; set; } = default!;
  public DbSet<Post> Posts { get; set; } = default!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {

    //optionsBuilder
    //    .UseSqlServer(
    //        @"Server=(localdb)\mssqllocaldb;Database=Querying.QueryFilters.Blogging;Trusted_Connection=True");

    var connectionString = $"Data Source={_directoryPath}\\Querying.QueryFilters.Blogging.sqlite";

    optionsBuilder.UseSqlite(connectionString);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Blog>().Property<string>("_tenantId").HasColumnName("TenantId");

    // Configure entity filters
    #region FilterConfiguration
    modelBuilder.Entity<Blog>().HasQueryFilter(b => EF.Property<string>(b, "_tenantId") == _tenantId);
    modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsDeleted);
    #endregion
  }

  public override int SaveChanges()
  {
    ChangeTracker.DetectChanges();

    foreach (var item in ChangeTracker.Entries().Where(
                 e =>
                     e.State == EntityState.Added && e.Metadata.GetProperties().Any(p => p.Name == "_tenantId")))
    {
      item.CurrentValues["_tenantId"] = _tenantId;
    }

    foreach (var item in ChangeTracker.Entries<Post>().Where(e => e.State == EntityState.Deleted))
    {
      item.State = EntityState.Modified;
      item.CurrentValues["IsDeleted"] = true;
    }

    return base.SaveChanges();
  }
}
