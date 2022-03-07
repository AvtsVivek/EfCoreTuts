using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ef000302_PieBakeryConsole;

public class BakeryDbContext : DbContext
{
  public BakeryDbContext(DbContextOptions<BakeryDbContext> options) : base(options)
  {

  }

  public DbSet<Pie> Pies { get; set; } = default!;
  public DbSet<Category> Categories { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfiguration(new PieEntityTypeConfiguration());
    modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
  }
}

internal class BakeryDbContextFactory : IDesignTimeDbContextFactory<BakeryDbContext>
{
  public BakeryDbContext CreateDbContext(string[] args)
  {
    var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EfPieIngredents;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    var optionsBuilder = new DbContextOptionsBuilder<BakeryDbContext>();
    optionsBuilder.UseSqlServer(connectionString);
    return new BakeryDbContext(optionsBuilder.Options);
  }
}
