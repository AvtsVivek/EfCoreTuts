using Microsoft.EntityFrameworkCore;

namespace Ef000210_SimpleHiLo.Tests;

public class InMemorySimpleHiLoTest : SimpleHiLoTest
{
  public InMemorySimpleHiLoTest() : base(
          new DbContextOptionsBuilder<AppDbContext>()
              .UseInMemoryDatabase("TestDatabase")
              .Options)
  {
    // Looks like in memory does not support sequences.
  }
}
