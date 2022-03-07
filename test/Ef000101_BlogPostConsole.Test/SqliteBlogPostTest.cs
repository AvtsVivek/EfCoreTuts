using Microsoft.EntityFrameworkCore;


namespace Ef000101_BlogPostConsole.Test;

public class SqliteBlogPostTest : BlogPostTest
{
  public SqliteBlogPostTest()
      : base(new DbContextOptionsBuilder<BloggingContext>()
              .UseSqlite("Filename=Test.db").Options)
  {

  }
}
