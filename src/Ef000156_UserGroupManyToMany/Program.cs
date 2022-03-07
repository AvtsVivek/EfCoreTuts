// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Ef000156_UserGroupManyToMany;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("This example is from here.");
        Console.WriteLine("https://www.youtube.com/watch?v=b2klBzcALJc");

        Console.WriteLine("The following are some references");
        Console.WriteLine("https://youtu.be/p0UJdoBj-Lc?t=1211");
        Console.WriteLine("https://www.youtube.com/watch?v=W1sxepfIMRM");
        Console.WriteLine("");

        Console.WriteLine("Ef core has a feature called Debug View or DebugView");
        Console.WriteLine("Take a look at the following.");
        Console.WriteLine("https://stackoverflow.com/a/70550987/1977871");

        using (var groupsContext = new GroupsContext())
        {
            groupsContext.Database.EnsureDeleted();
            groupsContext.Database.EnsureCreated();

            SomeData.AssociateGroupsToUsers();
            groupsContext.AddRange(SomeData.GetSomeUsers());
            groupsContext.AddRange(SomeData.GetSomeGroups());

            Console.WriteLine("Now take a look at the debug view of the model available on the context");

            groupsContext.SaveChanges();

        }

        Console.WriteLine("Ef core is designed to be Unit of Work.");
        Console.WriteLine("I get a bunch of data from the database(using the context)");
        Console.WriteLine("I do some manipulation on the data, like adding or updating(again using the context)");
        Console.WriteLine("And then I persist back to the database.");


        using (var groupsContext = new GroupsContext())
        {
            var users = groupsContext.Users.Include(user => user.Groups).ToList();
            Console.WriteLine();
            Console.WriteLine();

            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.Name}");
                foreach (var group in user.Groups)
                    Console.WriteLine($"    Group: {group.Name}");
                
            }
            groupsContext.Database.EnsureDeleted();
        }
    }
}
