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

// https://tall-nova-c74.notion.site/Office-Type-a67bf29972224c1eae142edc50502f30
// https://www.figma.com/proto/i7bDKtCGcihmJrMZQyUaBV/Signup?node-id=2%3A23788&scaling=min-zoom&page-id=0%3A1&starting-point-node-id=2%3A23788&show-proto-sidebar=1
