using Ef010702_OnboardTrials.CompanyAggregate;
using Ef010702_OnboardTrials.ReferenceDataAggregate;
using Microsoft.EntityFrameworkCore;

namespace Ef010702_OnboardTrials.DataAccess;

public interface ICompanyContext : IDataContextTransaction
{
    DbSet<DepartmentMaster> DepartmentMaster { get; set; }

    DbSet<SubDepartmentMaster> SubDepartmentMaster { get; set; }

    DbSet<CompanySizeMaster> CompanySizeMaster { get; set; }

    DbSet<IndustryTypeMaster> IndustryTypeMaster { get; set; }

    DbSet<OfficeTypeMaster> OfficeTypeMaster { get; set; }

    DbSet<Company> Companies { get; set; }

    // https://gunnarpeipman.com/ef-core-repository-unit-of-work/
}
