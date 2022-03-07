using Items;
using Microsoft.EntityFrameworkCore;

namespace ItemsWebApi.Tests;

public class InMemoryItemsControllerTest : ItemsControllerTest
{
  public InMemoryItemsControllerTest()
      : base(
          new DbContextOptionsBuilder<ItemsContext>()
              .UseInMemoryDatabase("TestDatabase")
              .Options)
  {
  }
}
