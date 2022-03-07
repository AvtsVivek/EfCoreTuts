using Microsoft.EntityFrameworkCore;

namespace Ef000211_CategoryProductsHiLo.Tests;

public class InMemoryCategoryProductsHiLoTest : CategoryProductsHiLoTest
{
  public InMemoryCategoryProductsHiLoTest() : base(
          new DbContextOptionsBuilder<AppDbContext>()
              .UseInMemoryDatabase("TestDatabase")
              .Options)
  {
    // Looks like in memory does not support sequences.
  }
}
