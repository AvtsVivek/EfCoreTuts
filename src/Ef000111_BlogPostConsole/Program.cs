// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Diagnostics;
using Ef000111_BlogPostConsole;
using Microsoft.EntityFrameworkCore;

public class Program
{
  public static void Main()
  {

    Console.WriteLine("This example is from here.");
    Console.WriteLine("https://docs.microsoft.com/en-us/ef/core/querying/tags");
    Console.WriteLine("Ef core has a feature called Debug View or DebugView");
    Console.WriteLine("Take a look at the following.");
    Console.WriteLine("https://stackoverflow.com/a/70550987/1977871");

    var contextOptions = new DbContextOptionsBuilder<BloggingContext>().UseSqlServer(BloggingContext.ConnectionString).Options;

    using (var context = new BloggingContext(contextOptions))
    {
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      var blog = new Blog() { Url = "http://vivek.blog.mewurk.org" };
      var post = new Post()
      {
        //Id = 1,
        Blog = blog,
        Title = "My First Post",
        Content = "Hello World, This is my first post!!"
      };
      
      context.Add(blog);
      context.Add(post);
      context.SaveChanges();
    }

    Console.WriteLine("Ef core is designed to be Unit of Work.");
    Console.WriteLine("I get a bunch of data from the database(using the context)");
    Console.WriteLine("I do some manipulation on the data, like adding or updating(again using the context)");
    Console.WriteLine("And then I persist back to the database.");


    using (var context = new BloggingContext(contextOptions))
    {
      var queryTag = "This is my blog query!";
      context.ChangeTracker.LazyLoadingEnabled = false;
      var blogs = context.Blogs.TagWith(queryTag);
      var myBlog = blogs.FirstOrDefault();
      Console.WriteLine($"You will see the query tag applied - {queryTag} in the log output.");
      Console.WriteLine("Ensure logging is configured.");
      context.Database.EnsureDeleted();
    }

    using (var context = new BloggingContext(contextOptions))
    {
      Console.WriteLine("Ensure to delete the database, else, it is left handing around, unnecessarly.");
      context.Database.EnsureDeleted();
    }
  }
}
