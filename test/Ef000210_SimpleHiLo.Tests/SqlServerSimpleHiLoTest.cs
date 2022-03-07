using Microsoft.EntityFrameworkCore;


namespace Ef000210_SimpleHiLo.Tests;

public class SqlServerSimpleHiLoTest : SimpleHiLoTest
{
  public SqlServerSimpleHiLoTest()
      : base(new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SimpleHiLoTest;Trusted_Connection=True")
            .Options)
  {

  }
}
