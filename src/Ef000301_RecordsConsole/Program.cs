// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Ef000301_RecordsConsole;

internal class Program
{
  private static void Main()
  {
    var fileName = "bakery.db";

    Console.WriteLine("This is based on ");
    Console.WriteLine("https://www.youtube.com/watch?v=bzI5g6PVM-I");
    Console.WriteLine("How to use EF Core 5 with DDD style projects - part 1");
    Console.WriteLine($"The file {fileName} will be created in the directory of the source code location");
    Console.WriteLine($"and not in bin folder.");
    Console.WriteLine($"This is because we have the tag <StartWorkingDirectory>$(MSBuildProjectDirectory)</StartWorkingDirectory> in the proj directory.");

    var useSqlServer = false; // Use what ever you are comfirtable with.

    var dbContextOptionsBuilder = new DbContextOptionsBuilder<BakeryDbContext>();

    if (useSqlServer)
      dbContextOptionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EfBakery;Trusted_Connection=True");
    else
      dbContextOptionsBuilder.UseSqlite($"Filename={fileName}");

    var pie = Pie.Create("Apple Pie", "A pie with apple an it", new ServingSize(10, 30));

    using (var db = new BakeryDbContext(dbContextOptionsBuilder.Options))
    {
      db.Database.EnsureDeleted();
      db.Database.EnsureCreated();

      db.Add(pie);
      db.SaveChanges();
    }

    using (var db = new BakeryDbContext(dbContextOptionsBuilder.Options))
    {
      var pieFromDb = db.Pies.ToList().FirstOrDefault();

      if (pieFromDb != null)
        Console.WriteLine($"Here is the pie from db: " + pieFromDb!.ToString());
    }

    using (var db = new BakeryDbContext(dbContextOptionsBuilder.Options))
    {
      Debugger.Break();
      // Ensure to delete, else they will be hanging around unnecessarly.
      db.Database.EnsureDeleted();
    }

  }
}
