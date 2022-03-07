using Microsoft.EntityFrameworkCore;


namespace Ef000210_SimpleHiLo.Tests;

public class SqliteSimpleHiLoTest : SimpleHiLoTest
{
  public SqliteSimpleHiLoTest()
      : base(new DbContextOptionsBuilder<AppDbContext>()
              .UseSqlite("Filename=Test.db").Options)
  {

  }
}
