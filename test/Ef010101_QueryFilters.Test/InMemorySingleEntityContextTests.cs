using Ef010101_QueryFilters;
using Microsoft.EntityFrameworkCore;

namespace Ef010101_QueryFilters.Test;

public class InMemorySingleEntityContextTests : SingleEntityContextTests
{
  public InMemorySingleEntityContextTests() : base(
          new DbContextOptionsBuilder<SingleEntityContext>()
              .UseInMemoryDatabase("TestDatabase")
              .Options)
  {
    ///      var options = SqliteInMemory.CreateOptions<MyDbContext>();
  }
}
