namespace MeWurk.Hrms.CompanyOnboarding.Core.ReferenceDataAggregate;

internal class ReferenceDataService
{
  public ReferenceDataService()
  {

  }

  private readonly List<DepartmentMaster> _departmentDefaultList = new List<DepartmentMaster>();
  public IReadOnlyCollection<DepartmentMaster> DepartmentDefaultList => _departmentDefaultList.AsReadOnly();
  public void AddCompanySizeDefaultList(List<DepartmentMaster> departmentDefaultList)
  {
    _departmentDefaultList?.AddRange(departmentDefaultList);
  }

  private readonly List<SubDepartmentMaster> _subDepartmentDefaultList = new List<SubDepartmentMaster>();
  public IReadOnlyCollection<SubDepartmentMaster> SubDepartmentDefaultList => _subDepartmentDefaultList.AsReadOnly();
  public void AddSubDepartmentDefaultList(List<SubDepartmentMaster> subDepartmentDefaultList)
  {
    _subDepartmentDefaultList?.AddRange(subDepartmentDefaultList);
  }


  private readonly List<CompanySizeMaster> _companySizeDefaultList = new List<CompanySizeMaster>();
  public IReadOnlyCollection<CompanySizeMaster> CompanySizeDefaultList => _companySizeDefaultList.AsReadOnly();
  public void AddCompanySizeDefaultList(List<CompanySizeMaster> companySizeDefaultList)
  {
    _companySizeDefaultList?.AddRange(companySizeDefaultList);
  }

  private readonly List<IndustryTypeMaster> _industryTypeDefaultList = new List<IndustryTypeMaster>();
  public IReadOnlyCollection<IndustryTypeMaster> IndustryTypeDefaultList => _industryTypeDefaultList.AsReadOnly();
  public void AddIndustryTypeDefaultList(List<IndustryTypeMaster> industryTypeDefaultList)
  {
    _industryTypeDefaultList?.AddRange(industryTypeDefaultList);
  }

  private readonly List<OfficeTypeMaster> _officeTypeDefaultList = new List<OfficeTypeMaster>();
  public IReadOnlyCollection<OfficeTypeMaster> OfficeTypeDefaultList => _officeTypeDefaultList.AsReadOnly();
  public void AddOfficeTypeDefaultList(List<OfficeTypeMaster> officeTypeDefaultList)
  {
    _officeTypeDefaultList?.AddRange(officeTypeDefaultList);
  }
}
