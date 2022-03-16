using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Ef000302_PieBakeryConsole;

internal class Program
{
  private static async Task Main()
  {
    var fileName = "bakery.db";

    Console.WriteLine("This is based on ");
    Console.WriteLine("https://www.youtube.com/watch?v=D1hSU-q3GLc");
    Console.WriteLine("How to use EF Core 5 with DDD style projects - part 2");
    Console.WriteLine($"The file {fileName} will be created in the directory of the source code location");
    Console.WriteLine($"and not in bin folder.");
    Console.WriteLine($"This is because we have the tag <StartWorkingDirectory>$(MSBuildProjectDirectory)</StartWorkingDirectory> in the proj directory.");

    var useSqlServer = false; // Use what ever you are comfirtable with.

    var dbContextOptionsBuilder = new DbContextOptionsBuilder<BakeryDbContext>();

    if (useSqlServer)
      dbContextOptionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EfPieIngredents;Trusted_Connection=True");
    else
      dbContextOptionsBuilder.UseSqlite($"Filename={fileName}");

    var ingredints = new List<Ingredient>(){

                new Ingredient("Cheese", false, 0.5),
                new Ingredient("Olive", true, 0.2),
                new Ingredient("Pepper", true, 0.3),
            };

    var category = new Category(new Guid(), "Birthday Specials");

    var pie = Pie.Create("Apple Pie", "A pie with apple an it", new Portions(10, 30), category);

    pie.UpdateIngredients(ingredints);

    using (var db = new BakeryDbContext(dbContextOptionsBuilder.Options))
    {
      db.Database.EnsureDeleted();
      db.Database.EnsureCreated();

      db.Add(pie);
      db.SaveChanges();
    }
    Guid pieId = Guid.Empty;
    using (var db = new BakeryDbContext(dbContextOptionsBuilder.Options))
    {
      var pieFromDb = db.Pies.ToList().FirstOrDefault();

      pieId = pieFromDb!.Id;

      if (pieFromDb != null)
        Console.WriteLine($"Here is the pie from db: " + pieFromDb!.ToString());

    }

    using (var db = new BakeryDbContext(dbContextOptionsBuilder.Options))
    {
      // Now get the pie from repo.
      var pieRepo = new PieRepository(db);

      var pieFromRepo = await pieRepo.FindByIdAsync(pieId);
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
