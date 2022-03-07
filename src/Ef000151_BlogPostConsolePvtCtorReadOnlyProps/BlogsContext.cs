// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class BlogsContext : DbContext
{
    public static string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=EfCoreBlogsAndPosts;";
    public DbSet<Blog> Blogs { get; set; } = default!;
    public DbSet<Post> Posts { get; set; } = default!;

    // This is a shorter alternative
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder
    //    .LogTo(Console.WriteLine, LogLevel.Information)
    //    .EnableSensitiveDataLogging()
    //    .EnableDetailedErrors()
    //    .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EfCoreBlogsAndPosts");

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
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Ef does not map readonly properties by default, we have to ask ef to map the Name,
        // even though Name is readonly
        modelBuilder.Entity<Blog>(b =>
            b.Property(e => e.Name)
        );
    }
}
