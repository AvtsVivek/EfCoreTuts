using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ef010702_CompanyOnboarding.Core.CompanyAggregate;
using Ef010702_CompanyOnboarding.Core.DataAccess;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ef010702_CompanyOnboarding.Core.Tests.Integration;

public class SqlServerCompanyCoreBasicTests : CompanyCoreBasicTests
{
  public SqlServerCompanyCoreBasicTests()
      : base(new DbContextOptionsBuilder<CompanyContext>()
            .UseSqlServer(CompanyContext.ConnectionString).Options)
  { }
}


public abstract class CompanyCoreBasicTests
{
  protected DbContextOptions<CompanyContext> ContextOptions { get; }
  protected CompanyCoreBasicTests(DbContextOptions<CompanyContext> contextOptions)
  {
    ContextOptions = contextOptions;
    //Seed();
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
      company_zero.SubDomain.Should().Be("MeWurk");
      company_zero.Language.Should().Be("English");
      company_zero.IndustryType.Should().Be("Services");
      company_zero.SocialProfiles.Count.Should().Be(0);
      //company_zero.Departments.Count.Should().Be(1);
      //company_zero.Departments.FirstOrDefault()!.Name.Should().Be("Engg");
      //company_zero.Departments.FirstOrDefault()!.Description.Should().Be("Engineering Dept");
      //company_zero.Departments.FirstOrDefault()!.SubDepartments.Count.Should().Be(2);

      //var subDepartment = company_zero.Departments.FirstOrDefault()!.SubDepartments.FirstOrDefault();
      //subDepartment.Should().NotBeNull();
      //subDepartment!.Name.Should().Be("Welding Shop");
      //subDepartment!.Description.Should().Be("Welding Mechanical Engg");

      var company_one = companies[1];

      company_one.Name.Should().Be("MxWork");
      company_one.SubDomain.Should().Be("MxWork");
      company_one.Language.Should().Be("English");
      company_one.IndustryType.Should().Be("SoftwareIndustry");
      company_one.SocialProfiles.Count.Should().Be(3);
      company_one.SocialProfiles.FirstOrDefault()!.Link.Should().Be("MxWorkLinkedIn");

      //companyContext.Remove(company_one);
      //companyContext.SaveChanges();
    }

    using (var companyContext = new CompanyContext(ContextOptions))
    {
      //var companies = await companyContext.Companies.ToListAsync();
      //companies.Count.Should().Be(1);
      //var company_zero = companies[0];

      //company_zero.Name.Should().Be("MeWurk");
      //company_zero.SubDomain.Should().Be("MeWurk");
      //company_zero.Language.Should().Be("English");
      //company_zero.IndustryType.Should().Be(IndustryType.Services);
      //company_zero.SocialProfiles.Count.Should().Be(0);

      //companyContext.Database.EnsureDeleted();
    }
  }

  private void PopulateDatabase(CompanyContext companyContext)
  {
    var company_zero = new Company("MeWurk", "MeWurk", "Services", new List<SocialProfile>(), "Corprate", "1 - 50");

    var enggDept = new Department("Engg", "Engineering Dept");

    enggDept.AddSubDepartments(new List<SubDepartment> {
                new SubDepartment("Welding Shop", "Welding Mechanical Engg"),
                new SubDepartment("Forging Shop", "Forging Mechanical Engg")
            });

    //company_zero.AddDepartments(new List<Department> {
    //            enggDept
    //        });

    companyContext.Add(company_zero);

    var socialProfiles = new List<SocialProfile>()
                {
                    new SocialProfile("MxWorkLinkedIn", "Linked in profile for MxWork"),
                    new SocialProfile("MxWorkTwitterId", "Twitter for MxWork"),
                    new SocialProfile("MxWorkKooId", "Koo for MxWork"),
                };

    var company_one = new Company("MxWork", "MxWork", "SoftwareIndustry", socialProfiles, "Corporate", "1 - 50");
    companyContext.Add(company_one);
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
