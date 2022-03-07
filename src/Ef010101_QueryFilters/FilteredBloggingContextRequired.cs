namespace Ef010101_QueryFilters;
using Microsoft.EntityFrameworkCore;

public class FilteredBloggingContextRequired : DbContext
{
  public DbSet<Blog> Blogs { get; set; } = default!;
  public DbSet<Post> Posts { get; set; } = default!;
  private readonly string _directoryPath;
  public FilteredBloggingContextRequired(string directoryPath)
  {
    _directoryPath = directoryPath;
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    //Data Source=database.sqlite
    //optionsBuilder
    //    .UseSqlServer(
    //        @"Server=(localdb)\mssqllocaldb;Database=Querying.QueryFilters.BloggingRequired;Trusted_Connection=True");

    var connectionString = $"Data Source={_directoryPath}\\Querying.QueryFilters.BloggingRequired.sqlite";

    optionsBuilder.UseSqlite(connectionString);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    var setup = "OptionalNav";
    if (setup == "Faulty")
    {
      // Incorrect setup - Required navigation used to reference entity that has query filter defined,
      // but no query filter for the entity on the other side of the navigation.
      #region IncorrectFilter
      modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne(p => p.Blog).IsRequired();
      modelBuilder.Entity<Blog>().HasQueryFilter(b => b.Url.Contains("fish"));
      #endregion
    }
    else if (setup == "OptionalNav")
    {
      // The relationship is marked as optional so dependent can exist even if principal is filtered out.
      #region OptionalNavigation
      modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne(p => p.Blog).IsRequired(false);
      modelBuilder.Entity<Blog>().HasQueryFilter(b => b.Url.Contains("fish"));
      #endregion
    }
    else if (setup == "NavigationInFilter")
    {
      #region NavigationInFilter
      modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne(p => p.Blog);
      modelBuilder.Entity<Blog>().HasQueryFilter(b => b.Posts.Count > 0);
      modelBuilder.Entity<Post>().HasQueryFilter(p => p.Title.Contains("fish"));
      #endregion
    }
    else
    {
      // The relationship is still required but there is a matching filter configured on dependent side too,
      // which matches principal side. So if principal is filtered out, the dependent would also be.
      #region MatchingFilters
      modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne(p => p.Blog).IsRequired();
      modelBuilder.Entity<Blog>().HasQueryFilter(b => b.Url.Contains("fish"));
      modelBuilder.Entity<Post>().HasQueryFilter(p => p.Blog.Url.Contains("fish"));
      #endregion
    }
  }
}
