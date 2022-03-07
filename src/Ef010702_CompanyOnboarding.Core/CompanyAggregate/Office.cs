using MeWurk.Hrms.CompanyOnboarding.Core.ValueObjects;
using PluralsightDdd.SharedKernel;

namespace MeWurk.Hrms.CompanyOnboarding.Core.CompanyAggregate;

public class Office : BaseEntity<ushort>
{
  private Office() { }
  public Office(string name, string officeType)
  {
    Name = name ?? throw new ArgumentNullException($"The argument {nameof(name)} is maditory");

    if (officeType == null)
      Type = "Corporate";
    else
      Type = officeType;
  }
  public long CompanyId { get; private set; } = default!;
  public string Name { get; private set; } = default!;
  public string Type { get; private set; } = default!;
  public string TimeZone { get; private set; } = default!;
  public bool IsActive { get; private init; } = true;

  public OfficeContact Contact { get; private init; } = default!;
  public OfficeLocation Location { get; private init; } = default!;

  // Do we need this relation ship? Need to check.
  private readonly List<Department> _departments = new List<Department>();
  public IReadOnlyCollection<Department> Departments => _departments.AsReadOnly();

}
// https://tall-nova-c74.notion.site/Ability-to-add-Office-d332c86b0b034aa7a1477e0384cfb150
// https://tall-nova-c74.notion.site/Office-Type-a67bf29972224c1eae142edc50502f30
