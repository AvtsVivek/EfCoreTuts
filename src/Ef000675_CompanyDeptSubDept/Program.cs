using Microsoft.EntityFrameworkCore;

namespace Ef000675_CompanyDeptSubDept;

internal class Program
{
  private static void Main()
  {
    TestCompany();
  }

  public static void TestCompany()
  {
    var dbContextOptions = new DbContextOptionsBuilder<CompanyContext>()
        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MeWurkCompanyDept").Options;

    using (var companyContext = new CompanyContext(dbContextOptions))
    {
      companyContext.Database.EnsureDeleted();
      companyContext.Database.EnsureCreated();
    }
  }
}
