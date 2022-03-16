using Ef010701_CompanyOnboarding.Core.ReferenceDataAggregate;
using MeWurk.Hrms.CompanyOnboarding.Core.CompanyAggregate;
using Microsoft.EntityFrameworkCore;

namespace Ef010701_CompanyOnboarding.Core.DataAccess;

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
