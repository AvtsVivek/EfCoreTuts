using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

public class GroupsContext : DbContext
{
    public static string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=EfCoreUsersAndGroups;";
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Group> Groups { get; set; } = default!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Action<string> consoleLogger = logInfo => Console.WriteLine(logInfo);

        // To see the output from the following 'Debug logger',
        // open the Output window(View -> Output or Ctrl + Alt + O)
        // and then select Debug from the see output from dropdown
        Action<string> debugWindowLogger = logInfo => Debug.WriteLine(logInfo);

        optionsBuilder
        // 
        //.LogTo(consoleLogger, LogLevel.Information)

        .LogTo(debugWindowLogger, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
        .UseSqlServer(ConnectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //// This following is not anything different.
        //// Here we are explicitly stating to use GroupUser 
        //// But thats what the conventions of Ef Core also do.
        //modelBuilder.SharedTypeEntity<Dictionary<string, object>>("GroupUser");
        //
        //// This is how we explicitly do the many-to-many configuration.
        //modelBuilder.Entity<User>().HasMany(user => user.Groups)
        //    .WithMany(group => group.Users);

        //// The following will produce exactly same as the default convention based does.
        //// Here we are explicitly configuring. But this is same as what ef core would expliitly configure.
        //modelBuilder.Entity<User>().HasMany(user => user.Groups)
        //    .WithMany(group => group.Users)
        //    .UsingEntity<Dictionary<string, object>>("GroupUser",
        //    groupuser => groupuser.HasOne<Group>().WithMany().HasForeignKey("GroupsId"),
        //    groupuser => groupuser.HasOne<User>().WithMany().HasForeignKey("UsersId"));

        // The following modifies a bit.
        // https://youtu.be/b2klBzcALJc?t=1075
        // Here we are explicitly configuring.
        modelBuilder.Entity<User>().HasMany(user => user.Groups)
            .WithMany(group => group.Users)
            .UsingEntity<Dictionary<string, object>>("Membership",
            groupuser => groupuser.HasOne<Group>().WithMany().HasForeignKey("GroupId"),
            groupuser => groupuser.HasOne<User>().WithMany().HasForeignKey("UserId"));

    }
}

public class BloggingContextFactory : IDesignTimeDbContextFactory<GroupsContext>
{
    public GroupsContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<GroupsContext>()
              .UseSqlServer(GroupsContext.ConnectionString).Options;

        return new GroupsContext();
    }
}

