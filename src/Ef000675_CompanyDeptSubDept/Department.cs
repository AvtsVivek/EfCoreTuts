namespace Ef000675_CompanyDeptSubDept;

public class Department //: ValueObject
{
  public Department(string name)
  {
    Name = name;
  }
  private readonly List<SubDepartment> _subDepartments = new List<SubDepartment>();
  public string Name { get; private init; } = default!;
  public IReadOnlyCollection<SubDepartment> SubDepartments => _subDepartments.AsReadOnly();
  //protected override IEnumerable<object> GetEqualityComponents()
  //{
  //    yield return Name;
  //}
}
public class SubDepartment //: ValueObject
{
  public SubDepartment(string name)
  {
    Name = name;
  }
  public string Name { get; private init; } = default!;
  //protected override IEnumerable<object> GetEqualityComponents()
  //{
  //    yield return Name;
  //}
}
