using Microsoft.EntityFrameworkCore;

namespace Ef000201_GetStartedConsole;

public class BloggingContext : DbContext
{
  public DbSet<Blog> Blogs { get; set; } = default!;
  public DbSet<Post> Posts { get; set; } = default!;

  public string DbPath { get; } = default!;

  public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
  {

  }

  public BloggingContext()
  {
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);
    DbPath = Path.Join(path, "blogging.db");
  }

  // The following configures EF to create a Sqlite database file in the
  // special "local" folder for your platform.
  //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {

  }
}
