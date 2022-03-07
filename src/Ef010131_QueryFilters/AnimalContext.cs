using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ef010131_QueryFilters;

using Microsoft.EntityFrameworkCore;


public class AnimalContext : DbContext
{
  public DbSet<Person> People { get; set; } = default!;
  public DbSet<Animal> Animals { get; set; } = default!;
  public DbSet<Toy> Toys { get; set; } = default!;

  public AnimalContext(string directoryPath)
  {
    _directoryPath = directoryPath;
  }

  private readonly string _directoryPath;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    //optionsBuilder
    //    .UseSqlServer(
    //        @"Server=(localdb)\mssqllocaldb;Database=Querying.QueryFilters.Animals;Trusted_Connection=True");

    var connectionString = $"Data Source={_directoryPath}\\Querying.QueryFilters.Animals.sqlite";
    optionsBuilder.UseSqlite(connectionString);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Cat>().HasOne(c => c.Tolerates).WithOne(d => d.FriendsWith).HasForeignKey<Cat>(c => c.ToleratesId);
    modelBuilder.Entity<Dog>().HasOne(d => d.FavoriteToy).WithOne(t => t.BelongsTo).HasForeignKey<Toy>(d => d.BelongsToId);

    modelBuilder.Entity<Person>().HasQueryFilter(p => p.Pets.Count > 0);
    modelBuilder.Entity<Animal>().HasQueryFilter(a => !a.Name.StartsWith("P"));
    modelBuilder.Entity<Toy>().HasQueryFilter(a => a.Name.Length > 5);

    // Invalid query filter configuration as it causes cycles in query filters
    //modelBuilder.Entity<Animal>().HasQueryFilter(a => a.Owner.Name != "John");
  }
}
