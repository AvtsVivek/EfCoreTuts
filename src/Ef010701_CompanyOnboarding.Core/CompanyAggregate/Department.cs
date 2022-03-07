using PluralsightDdd.SharedKernel;

namespace MeWurk.Hrms.CompanyOnboarding.Core.CompanyAggregate;

public class Department : ValueObject
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

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Name;
  }
}
