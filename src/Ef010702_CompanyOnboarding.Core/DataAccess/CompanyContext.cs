using Ef010702_CompanyOnboarding.Core.CompanyAggregate;
using Ef010702_CompanyOnboarding.Core.ReferenceDataAggregate;
using MeWurk.Hrms.CompanyOnboarding.Core.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Ef010702_CompanyOnboarding.Core.DataAccess;

public class CompanyContext : BaseDbContext, ICompanyContext
{
  public static string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=MeWurkCompanyOnboarding;";
  public CompanyContext(DbContextOptions<CompanyContext> options)
      : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new CompanyTypeConfiguration());
    modelBuilder.ApplyConfiguration(new OfficeTypeConfiguration());
    modelBuilder.ApplyConfiguration(new EmployeeTypeConfiguration());
    modelBuilder.ApplyConfiguration(new DepartmentTypeConfiguration());
    // Instead of the above 4, I can use one line like this.
    // modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubscriptionContext).Assembly);

    PopulateDataIntoMaster(modelBuilder);

    //modelBuilder.Entity<OfficeTypeDefault>().HasData(
    //    new { BlogId = 1, PostId = 2, Title = "Second post", Content = "Test 2" });

  }
  public DbSet<DepartmentMaster> DepartmentMaster { get; set; } = default!;

  public DbSet<SubDepartmentMaster> SubDepartmentMaster { get; set; } = default!;

  public DbSet<CompanySizeMaster> CompanySizeMaster { get; set; } = default!;

  public DbSet<IndustryTypeMaster> IndustryTypeMaster { get; set; } = default!;

  public DbSet<OfficeTypeMaster> OfficeTypeMaster { get; set; } = default!;

  public DbSet<Company> Companies { get; set; } = default!;

  public DbSet<Employee> Employees { get; set; } = default!;

  public DbSet<Office> Offices { get; set; } = default!;

  private void PopulateDataIntoMaster(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<OfficeTypeMaster>().HasData(
        new OfficeTypeMaster("Research & Development", "Research & Development") { Id = 1 });
    modelBuilder.Entity<OfficeTypeMaster>().HasData(
        new OfficeTypeMaster("Head Quarter", "Head Quarter") { Id = 2 });
    modelBuilder.Entity<OfficeTypeMaster>().HasData(
        new OfficeTypeMaster("Corporate", "Corporate office") { Id = 3 });
    modelBuilder.Entity<OfficeTypeMaster>().HasData(
        new OfficeTypeMaster("Manufacturing Unit", "Manufacturing Unit") { Id = 4 });
    modelBuilder.Entity<OfficeTypeMaster>().HasData(
        new OfficeTypeMaster("Factory", "Factory") { Id = 5 });
    modelBuilder.Entity<OfficeTypeMaster>().HasData(
        new OfficeTypeMaster("Outlet", "Outlet") { Id = 6 });
    modelBuilder.Entity<OfficeTypeMaster>().HasData(
        new OfficeTypeMaster("Office", "Office") { Id = 7 });
    modelBuilder.Entity<OfficeTypeMaster>().HasData(
        new OfficeTypeMaster("Warehouse", "Warehouse") { Id = 8 });
    modelBuilder.Entity<OfficeTypeMaster>().HasData(
        new OfficeTypeMaster("Sales", "Sales") { Id = 9 });
    modelBuilder.Entity<OfficeTypeMaster>().HasData(
        new OfficeTypeMaster("Others", "Others") { Id = 10 });


    modelBuilder.Entity<IndustryTypeMaster>().HasData(
        new IndustryTypeMaster("Agriculture", "Agriculture") { Id = 1 });
    modelBuilder.Entity<IndustryTypeMaster>().HasData(
        new IndustryTypeMaster("Manufacturing", "Manufacturing") { Id = 2 });
    modelBuilder.Entity<IndustryTypeMaster>().HasData(
        new IndustryTypeMaster("Services", "Services") { Id = 3 });
    modelBuilder.Entity<IndustryTypeMaster>().HasData(
        new IndustryTypeMaster("Software Industry", "Software Industry") { Id = 4 });
    modelBuilder.Entity<IndustryTypeMaster>().HasData(
        new IndustryTypeMaster("Restaurant", "Restaurant") { Id = 5 });


    modelBuilder.Entity<CompanySizeMaster>().HasData(
        new CompanySizeMaster("1 - 50", "One to Fifty") { Id = 1 });
    modelBuilder.Entity<CompanySizeMaster>().HasData(
        new CompanySizeMaster("51 - 100", "Fifty to Hundred") { Id = 2 });
    modelBuilder.Entity<CompanySizeMaster>().HasData(
        new CompanySizeMaster("101 - 250", "Hundred to Twofifty") { Id = 3 });
    modelBuilder.Entity<CompanySizeMaster>().HasData(
        new CompanySizeMaster("251 - 500", "Twofifty to five hundred") { Id = 4 });
    modelBuilder.Entity<CompanySizeMaster>().HasData(
        new CompanySizeMaster("Above 500", "Above Five hundred") { Id = 5 });

  }
}
