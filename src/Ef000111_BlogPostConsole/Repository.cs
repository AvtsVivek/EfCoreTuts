using Microsoft.EntityFrameworkCore;

namespace Ef000111_BlogPostConsole;

public abstract class Repository<T> where T : class
{
  private readonly DbContextOptions<BloggingContext> _dbContextOptions;
  public Repository(DbContextOptions<BloggingContext> dbContextOptions)
  {
    _dbContextOptions = dbContextOptions;
    //var dbContextOptions = new DbContextOptionsBuilder<BloggingContext>().UseInMemoryDatabase("TestDatabase").Options; 
  }
  public T GetById(int id)
  {
    using (var db = new BloggingContext(_dbContextOptions))
    {
      var t = db.Find<T>(id)!;
      return t;
    }
  }

  public void Save(T aggregateRoot)
  {
    using (var db = new BloggingContext(_dbContextOptions))
    {
      db.Add(aggregateRoot);
      db.SaveChanges();
    }
  }
}
