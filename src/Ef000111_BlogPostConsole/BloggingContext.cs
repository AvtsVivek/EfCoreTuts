
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ef000111_BlogPostConsole;

public class BloggingContext : DbContext
{
  public static string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=EfBlogPostTestSample;";
  public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)  { }

  public DbSet<Blog> Blogs { get; set; } = default!;
  public DbSet<Post> Posts { get; set; } = default!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {

    Action<string> consoleLogger = logInfo => Console.WriteLine(logInfo);

    // To see the output from the following 'Debug logger',
    // open the Output window(View -> Output or Ctrl + Alt + O)
    // and then select Debug from the see output from dropdown
    Action<string> debugWindowLogger = logInfo => Debug.WriteLine(logInfo);

    optionsBuilder
    // 
    //.LogTo(consoleLogger, LogLevel.Information)
    .LogTo(debugWindowLogger, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
    // If you want to set the max batch size, you can set this here. 
    // But NOTE this is sql server specific.
    .UseSqlServer(ConnectionString, options => options.MaxBatchSize(100));


    optionsBuilder.UseLazyLoadingProxies(true);
    base.OnConfiguring(optionsBuilder);
  }



  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Blog>(blog => blog.HasMany(typeof(Post), "Posts")
    .WithOne(nameof(Blog)));
  }
}
