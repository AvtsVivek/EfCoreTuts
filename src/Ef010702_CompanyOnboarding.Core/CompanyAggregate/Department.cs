using PluralsightDdd.SharedKernel;

namespace Ef010702_CompanyOnboarding.Core.CompanyAggregate;

public class Department : BaseEntity<ushort>
{
  private readonly List<SubDepartment> _subDepartments = new List<SubDepartment>();
  public Department(string name, string description, bool isActive = true)
  {
    Name = name ?? throw new ArgumentNullException($"The argument {nameof(name)} cannot be null");
    Description = description;
    IsActive = isActive;
  }
  public string Name { get; private init; } = default!;
  public string Description { get; private init; } = default!;
  public bool IsActive { get; private init; } = true;
  public long CompanyId { get; private set; } = default!;

  public IReadOnlyCollection<SubDepartment> SubDepartments => _subDepartments.AsReadOnly();

  public void AddSubDepartments(List<SubDepartment> subDepartments)
  {
    if (subDepartments.Count == 0)
      throw new ArgumentException("SubDepartment argument has 0 count");

    // Add any business rules regarding sub departments here.

    if (_subDepartments.Count == 0)
      _subDepartments.AddRange(subDepartments);
    else
      throw new Exception($"Currently this is not yet implimented. " +
          $"This needs to be enhanced.");
  }

  // Do we need this relation ship? Need to check.
  private readonly List<Office> _offices = new List<Office>();
  public IReadOnlyCollection<Office> Offices => _offices.AsReadOnly();

}
