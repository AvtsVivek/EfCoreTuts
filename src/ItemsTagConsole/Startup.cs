using Microsoft.EntityFrameworkCore;

namespace ItemsTagConsole;

internal class Startup
{
  public void Run()
  {
    var dbContextOptions = new DbContextOptionsBuilder<ItemsContext>()
        .UseInMemoryDatabase("TestDatabase").Options;


    using (var context = new ItemsContext(dbContextOptions))
    {
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      var one = new Item("ItemOne");
      one.AddTag("Tag11");
      one.AddTag("Tag12");
      one.AddTag("Tag13");

      var two = new Item("ItemTwo");

      var three = new Item("ItemThree");
      three.AddTag("Tag31");
      three.AddTag("Tag31");
      three.AddTag("Tag31");
      three.AddTag("Tag32");
      three.AddTag("Tag32");

      context.AddRange(one, two, three);

      context.SaveChanges();
    }
  }
}
