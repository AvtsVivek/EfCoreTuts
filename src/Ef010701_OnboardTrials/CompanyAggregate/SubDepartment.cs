using PluralsightDdd.SharedKernel;

namespace Ef010701_OnboardTrials.CompanyAggregate;

public class SubDepartment : ValueObject
{
    // https://tall-nova-c74.notion.site/Ability-to-add-Sub-Department-092f3aaf6454424d9d3716a135e915e9
    public SubDepartment(string name, string description, bool isActive = true)
    {
        Name = name ?? throw new ArgumentNullException($"The argument {nameof(name)} cannot be null");
        Description = description;
        IsActive = isActive;
    }
    public string Name { get; private init; } = default!;
    public string Description { get; private init; } = default!;
    public bool IsActive { get; private init; } = true;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}
