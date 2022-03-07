using PluralsightDdd.SharedKernel;
using PluralsightDdd.SharedKernel.Interfaces;

namespace Ef000675_CompanyDeptSubDept;

public class Company : BaseEntity<long>, IAggregateRoot
{
  private Company() { }

  public Company(string name)
  {
    Name = name;
  }

  public string Name { get; private set; } = default!;
  private readonly List<Department> _departments = new List<Department>();
  public IReadOnlyCollection<Department> Departments => _departments.AsReadOnly();
}
