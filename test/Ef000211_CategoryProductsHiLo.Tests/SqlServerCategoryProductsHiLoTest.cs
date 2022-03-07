using Microsoft.EntityFrameworkCore;


namespace Ef000211_CategoryProductsHiLo.Tests;

public class SqlServerCategoryProductsHiLoTest : CategoryProductsHiLoTest
{
  public SqlServerCategoryProductsHiLoTest()
      : base(new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CategoryProductHiLoTest;Trusted_Connection=True")
            .Options)
  {

  }
}
