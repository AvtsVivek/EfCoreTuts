using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluralsightDdd.SharedKernel;
using PluralsightDdd.SharedKernel.Interfaces;

namespace MeWurk.Hrms.CompanyOnboarding.Core.CompanyAggregate;

public class Team : BaseEntity<long>, IAggregateRoot
{
  public string Name { get; private set; } = default!;
  public string Description { get; private set; } = default!;
  public bool IsActive { get; private set; } = default!;
  public long CompanyId { get; private set; } = default!;

  private readonly List<Employee> _employees = new List<Employee>();
  public IReadOnlyCollection<Employee> Employees => _employees.AsReadOnly();

  public Team(long companyId, string name, string description, bool isActive = true)
  {
    // Need to check companyId exists.
    // if(company id does not exist) throw new ArgumentException($"Company with id {companyId} could not be found!! ");
    CompanyId = companyId;

    // Need to do a unique check for name. 
    // https://tall-nova-c74.notion.site/Team-Name-f8455ec26a544503a64e94c93ae3c72b
    // if(name already exists) throw new ArgumentNullException($"{nameof(name)} must be empty");

    Name = name ?? throw new ArgumentNullException($"{nameof(name)} cannot be empty");
    Description = description;
    IsActive = isActive;
  }

  public void AddEmployee(Employee employee)
  {
    // Check for any invariants.
    // Check if the employee is
    // already added here to the same team.
    _employees.Add(employee);
  }
  public int Count => _employees.Count;
}

// https://tall-nova-c74.notion.site/Show-no-of-Employees-associated-with-this-Team-d3dc00698f274cf6bc146d49a0f4feca
// https://tall-nova-c74.notion.site/Ability-to-add-Team-0328b6e4c40147d9bee4756cecc271b3

