using Items;
using Microsoft.EntityFrameworkCore;

namespace ItemsWebApi.Tests;
public class SqliteItemsControllerTest : ItemsControllerTest
{
  public SqliteItemsControllerTest()
      : base(
          new DbContextOptionsBuilder<ItemsContext>()
              .UseSqlite("Filename=Test.db")
              .Options)
  {
  }
}
