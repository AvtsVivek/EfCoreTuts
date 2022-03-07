using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ef000301_RecordsConsole;

internal class BakeryDbContextFactory : IDesignTimeDbContextFactory<BakeryDbContext>
{
  public BakeryDbContext CreateDbContext(string[] args)
  {
    var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DddPieBakery;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    var optionsBuilder = new DbContextOptionsBuilder<BakeryDbContext>();
    optionsBuilder.UseSqlServer(connectionString);
    return new BakeryDbContext(optionsBuilder.Options);
  }
}
