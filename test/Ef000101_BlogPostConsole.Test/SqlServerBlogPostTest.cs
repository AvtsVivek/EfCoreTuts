using Microsoft.EntityFrameworkCore;


namespace Ef000101_BlogPostConsole.Test;

public class SqlServerBlogPostTest : BlogPostTest
{
  public SqlServerBlogPostTest()
      : base(new DbContextOptionsBuilder<BloggingContext>()
            .UseSqlServer(BloggingContext.ConnectionString)
            .Options)
  { }
}
