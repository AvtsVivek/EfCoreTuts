// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// EFGetStartedConsole

using Microsoft.EntityFrameworkCore;

namespace Ef000201_GetStartedConsole;

internal class Program
{
  private static void Main()
  {
    Console.WriteLine("This is example is based on the follwing");
    Console.WriteLine(@"https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli");

    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);
    var bloggingPath = Path.Join(path, "Blogging");
    var dbPath = Path.Join(bloggingPath, "blogging.db");

    var dbContextOptionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
    // This is not working.
    //dbContextOptionsBuilder.UseSqlite($"Filename={dbPath}");

    var fileName = "blogging.db";

    dbContextOptionsBuilder.UseSqlite($"Filename={fileName}");

    Console.WriteLine("Here we go...");
    Console.WriteLine($"The file {fileName} will be created in the directory of the source code location");
    Console.WriteLine($"and not in bin folder.");
    Console.WriteLine($"This is because we have the tag <StartWorkingDirectory>$(MSBuildProjectDirectory)</StartWorkingDirectory> in the proj directory.");

    using (var db = new BloggingContext(dbContextOptionsBuilder.Options))
    {
      db.Database.EnsureDeleted();
      db.Database.EnsureCreated();

      // Create
      Console.WriteLine("Inserting a new blog");
      db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
      db.SaveChanges();

      // Read
      Console.WriteLine("Querying for a blog");
      var blog = db.Blogs.OrderBy(b => b.BlogId).First();

      // Update
      Console.WriteLine("Updating the blog and adding a post");
      blog.Url = "https://devblogs.microsoft.com/dotnet";
      blog.Posts.Add(new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
      db.SaveChanges();

      // Delete
      Console.WriteLine("Delete the blog");
      db.Remove(blog);
      db.SaveChanges();
      db.Database.EnsureDeleted();
    }
  }
}

