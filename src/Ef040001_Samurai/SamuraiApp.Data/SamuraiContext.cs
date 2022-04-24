using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SamuraiApp.Domain;
using System;
using System.Diagnostics;
using System.IO;

namespace SamuraiApp.Data;

public class SamuraiContext : DbContext
{
    public DbSet<Samurai> Samurais { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Battle> Battles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=SamuraiAppDataFirstLook");
        // optionsBuilder.UseSqlite("Data Source = SamuraiAppDataFirstLook.sqlite");
        optionsBuilder.UseInMemoryDatabase(new Guid().ToString());

        optionsBuilder.LogTo(logMessage =>
            {
                Debugger.Break();
                Debug.WriteLine(logMessage);
                Console.WriteLine(logMessage);
                // var logStream = new StreamWriter("mylog.txt", append: true);
                // logStream.WriteLine(logMessage);
            },
            new[] {
              DbLoggerCategory.Database.Command.Name }, LogLevel.Information
        );

        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Samurai>()
            .HasMany(s => s.Battles)
            .WithMany(b => b.Samurais)
            .UsingEntity<BattleSamurai>
              (bs => bs.HasOne<Battle>().WithMany(),
               bs => bs.HasOne<Samurai>().WithMany())
             .Property(bs => bs.DateJoined)
             .HasDefaultValueSql("getdate()");
    }
}
