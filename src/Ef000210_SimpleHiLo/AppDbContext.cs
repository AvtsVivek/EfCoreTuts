using Microsoft.EntityFrameworkCore;

namespace Ef000210_SimpleHiLo;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {

  }

  public DbSet<Employee> Employees { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.HasSequence<int>("Seq2")
        .StartsAt(10)
        .IncrementsBy(5);

    modelBuilder.Entity<Employee>().Property(e => e.Id).UseHiLo("Seq2");

    //modelBuilder.ApplyConfiguration(new PieEntityTypeConfiguration());
    //modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
  }
}
