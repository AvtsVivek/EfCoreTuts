using Microsoft.EntityFrameworkCore;

namespace Ef000101_BlogPostConsole.Test;

public class InMemoryBlogPostTest : BlogPostTest
{
  public InMemoryBlogPostTest() : base(
          new DbContextOptionsBuilder<BloggingContext>()
              .UseInMemoryDatabase("TestDatabase")
              .Options)
  {

  }
}
