// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {

        Console.WriteLine("This example is from here.");
        Console.WriteLine("https://www.youtube.com/watch?v=p0UJdoBj-Lc");
        Console.WriteLine("Ef core has a feature called Debug View or DebugView");
        Console.WriteLine("Take a look at the following.");
        Console.WriteLine("https://stackoverflow.com/a/70550987/1977871");

        using (var context = new BlogsContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //context.Add(SomeData.GetABlogWithThreePosts());

            Console.WriteLine("Now here, the number of objects are more in number now, so it will do batch processing.");
            Console.WriteLine("Observer the output now.");
            context.Add(SomeData.GetABlogWithFivePosts());

            Debugger.Break();
            context.SaveChanges();
        }

        Console.WriteLine("Ef core is designed to be Unit of Work.");
        Console.WriteLine("I get a bunch of data from the database(using the context)");
        Console.WriteLine("I do some manipulation on the data, like adding or updating(again using the context)");
        Console.WriteLine("And then I persist back to the database.");


        using (var context = new BlogsContext())
        {
            var queryable = context.Blogs.Include(e => e.Posts);
            Console.WriteLine("IQueryable is delayed evaluation");

            Console.WriteLine(queryable.ToQueryString());
            Console.WriteLine("You can get the same above output ");
            Debugger.Break();
            var blogs = queryable.ToList();

            Console.WriteLine();
            Console.WriteLine();

            foreach (var blog in blogs)
            {
                Console.WriteLine($"Blog: {blog.Name}");
                foreach (var post in blog.Posts)
                {
                    Console.WriteLine($"  {post.Title}");
                }
            }
        }

        using (var context = new BlogsContext())
        {
            Console.WriteLine("Ensure to delete the database, else, it is left handing around, unnecessarly.");
            context.Database.EnsureDeleted();
        }
    }
}
