
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ef000101_BlogPostConsole;

public class BloggingContextFactory : IDesignTimeDbContextFactory<BloggingContext>
{
  public BloggingContext CreateDbContext(string[] args)
  {
    var options = new DbContextOptionsBuilder<BloggingContext>()
          .UseSqlServer(BloggingContext.ConnectionString).Options;
    //var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DddInPracticeWithEfCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    //var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
    //optionsBuilder.UseSqlServer(connectionString);
    //return new AppDbContext(optionsBuilder.Options);

    return new BloggingContext(options);
  }
}
