using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Ef000303_PieBakeryConsole;

internal class Program
{
  private static void Main()
  {
    var fileName = "bakery.db";
    var useSqlServer = true;
    var dbContextOptionsBuilder = new DbContextOptionsBuilder<BakeryDbContext>();

    if (useSqlServer)
      dbContextOptionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EfPieIngredents;Trusted_Connection=True");
    else
      dbContextOptionsBuilder.UseSqlite($"Filename={fileName}");

    var ingredints = new List<Ingredient>(){
                new Ingredient("Cheese"),
                new Ingredient("Nuts"),
            };

    var pie = Pie.Create("Apple Pie");

    pie.UpdateIngredients(ingredints);

    using (var db = new BakeryDbContext(dbContextOptionsBuilder.Options))
    {
      db.Database.EnsureDeleted();
      db.Database.EnsureCreated();

      db.Add(pie);
      db.SaveChanges();
      //db.Database.EnsureDeleted();
    }

    var pieId = Guid.Empty;

    using (var db = new BakeryDbContext(dbContextOptionsBuilder.Options))
    {
      var pieFromDb = db.Pies.ToList().FirstOrDefault();

      pieId = pieFromDb!.Id;

      if (pieFromDb != null)
        Console.WriteLine($"Here is the pie from db: " + pieFromDb!.ToString());

    }

    using (var db = new BakeryDbContext(dbContextOptionsBuilder.Options))
    {
      var pieFromDb = db.Pies.ToList().FirstOrDefault();

      if (pieFromDb != null)
        Console.WriteLine($"Here is the pie from db: " + pieFromDb!.ToString());

      Debugger.Break();
      db.Remove(pieFromDb!);
      db.SaveChanges();

      Console.WriteLine("Notice that once the pie is deleted from the database, ");
      Console.WriteLine("the ingredents are also removed from the database. ");

    }

    using (var db = new BakeryDbContext(dbContextOptionsBuilder.Options))
    {
      Debugger.Break();
      // Ensure to delete, else they will be hanging around unnecessarly.
      Console.WriteLine("Now the database is deleeted because they will be hanging around unnecessarly ");
      db.Database.EnsureDeleted();
    }

  }
}
