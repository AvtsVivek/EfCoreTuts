using PluralsightDdd.SharedKernel;

namespace MeWurk.Hrms.CompanyOnboarding.Core.ReferenceDataAggregate;

public abstract class MasterData : BaseEntity<short>
{
  public MasterData() { }

  public MasterData(string name, string description)
  {
    Name = name ?? throw new ArgumentNullException(nameof(name));
    Description = description;
  }
  public string Name { get; private set; } = default!;
  public string Description { get; private set; } = default!;
}

public class DepartmentMaster : MasterData
{
  private DepartmentMaster() { }

  public DepartmentMaster(string name, string description)
      : base(name, description) { }
}

public class SubDepartmentMaster : MasterData
{
  private SubDepartmentMaster() { }

  public SubDepartmentMaster(string name, string description)
      : base(name, description) { }
}

public class OfficeTypeMaster : MasterData
{
  private OfficeTypeMaster() { }

  public OfficeTypeMaster(string name, string description)
      : base(name, description) { }
}

public class CompanySizeMaster : MasterData
{
  private CompanySizeMaster() { }

  public CompanySizeMaster(string name, string description)
      : base(name, description) { }
}

public class IndustryTypeMaster : MasterData
{
  private IndustryTypeMaster() { }

  public IndustryTypeMaster(string name, string description)
      : base(name, description) { }
}
