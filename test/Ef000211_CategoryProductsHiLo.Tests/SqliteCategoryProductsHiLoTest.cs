using Microsoft.EntityFrameworkCore;


namespace Ef000211_CategoryProductsHiLo.Tests;

public class SqliteCategoryProductsHiLoTest : CategoryProductsHiLoTest
{
  public SqliteCategoryProductsHiLoTest()
      : base(new DbContextOptionsBuilder<AppDbContext>()
              .UseSqlite("Filename=Test.db").Options)
  {

  }
}
