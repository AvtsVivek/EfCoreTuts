using Microsoft.EntityFrameworkCore;

namespace Ef000101_BlogPostConsole;

internal class BlogRepository : Repository<Blog>
{
  public BlogRepository(DbContextOptions<BloggingContext> dbContextOptions) : base(dbContextOptions)
  {

  }
}
