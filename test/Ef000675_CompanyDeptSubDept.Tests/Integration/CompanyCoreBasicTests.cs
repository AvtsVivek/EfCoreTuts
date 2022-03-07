using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ef000675_CompanyDeptSubDept.Tests.Integration;

public class SomeTest
{
  [Fact]
  public void TestCompany()
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
public class SqlServerCompanyCoreBasicTests : CompanyCoreBasicTests
{
  public SqlServerCompanyCoreBasicTests()
      : base(new DbContextOptionsBuilder<CompanyContext>()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MeWurkCompanyDept").Options)
  { }
}

public abstract class CompanyCoreBasicTests
{
  protected DbContextOptions<CompanyContext> ContextOptions { get; }
  protected CompanyCoreBasicTests(DbContextOptions<CompanyContext> contextOptions)
  {
    ContextOptions = contextOptions;
    Seed();
  }

  [Fact]
  public async Task ThereShouldBeTwoCompaniesInTheDatabase()
  {
    using (var companyContext = new CompanyContext(ContextOptions))
    {
      //companyContext.ChangeTracker.LazyLoadingEnabled = false;

      companyContext.Database.EnsureDeleted();
      companyContext.Database.EnsureCreated();

      PopulateDatabase(companyContext);

      var companies = await companyContext.Companies.ToListAsync();
      companies.Count.Should().Be(2);
      var company_zero = companies[0];

      company_zero.Name.Should().Be("MeWurk");
      //company_zero.SubDomain.Should().Be("MeWurk");
      //company_zero.Language.Should().Be("English");
      //company_zero.IndustryType.Should().Be(IndustryType.Services);
      //company_zero.SocialProfiles.Count.Should().Be(0);
      company_zero.Departments.Count.Should().Be(1);
      company_zero.Departments.FirstOrDefault()!.Name.Should().Be("Engg");
      //company_zero.Departments.FirstOrDefault()!.Description.Should().Be("Engineering Dept");


      var company_one = companies[1];

      company_one.Name.Should().Be("MxWork");

      companyContext.Remove(company_one);
      companyContext.SaveChanges();
    }

    using (var companyContext = new CompanyContext(ContextOptions))
    {
      var companies = await companyContext.Companies.ToListAsync();
      companies.Count.Should().Be(1);
      var company_zero = companies[0];

      company_zero.Name.Should().Be("MeWurk");

      companyContext.Database.EnsureDeleted();
    }
  }

  private void PopulateDatabase(CompanyContext companyContext)
  {
    var company_one = new Company("MeWurk");

    var enggDept = new Department("Engg");

    //enggDept.AddSubDepartments(new List<SubDepartment> {
    //    new SubDepartment("Welding Shop", "Welding Mechanical Engg"),
    //    new SubDepartment("Forging Shop", "Forging Mechanical Engg")
    //});

    //company_one.AddDepartments(new List<Department> {
    //    enggDept
    //});

    companyContext.Add(company_one);

    var company_two = new Company("MxWork");
    companyContext.Add(company_two);
    companyContext.SaveChanges();
  }

  private void Seed()
  {
    using (var companyContext = new CompanyContext(ContextOptions))
    {
      companyContext.Database.EnsureDeleted();
      companyContext.Database.EnsureCreated();

      PopulateDatabase(companyContext);
    }
  }
}
