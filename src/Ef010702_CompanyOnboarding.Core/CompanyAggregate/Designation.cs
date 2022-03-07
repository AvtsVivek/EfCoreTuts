using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluralsightDdd.SharedKernel;
using PluralsightDdd.SharedKernel.Interfaces;

namespace MeWurk.Hrms.CompanyOnboarding.Core.CompanyAggregate;

public class Designation : BaseEntity<long>, IAggregateRoot
{
  public string Name { get; private set; } = default!;
  public string JobTitle { get; private set; } = default!;
  public string Description { get; private set; } = default!;
  public bool IsActive { get; private set; } = default!;
  public long CompanyId { get; private set; } = default!;

  // Do we need this relation ship? Need to check.
  private readonly List<Employee> _employees = new List<Employee>();
  public IReadOnlyCollection<Employee> Employees => _employees.AsReadOnly();

  public Designation(long companyId, string name, string description, string jobTitle, bool isActive = true)
  {
    // Need to check companyId exists.
    // if(company id does not exist) throw new ArgumentException($"Company with id {companyId} could not be found!! ");
    CompanyId = companyId;

    // Need to do a unique check for name. 
    // https://tall-nova-c74.notion.site/Team-Name-f8455ec26a544503a64e94c93ae3c72b
    // if(name already exists) throw new ArgumentNullException($"{nameof(name)} must be empty");

    Name = name ?? throw new ArgumentNullException($"{nameof(name)} cannot be empty");

    if(!string.IsNullOrWhiteSpace(jobTitle))
      JobTitle = jobTitle;
    JobTitle = name;

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

// https://tall-nova-c74.notion.site/A-text-to-show-no-of-Employees-associated-with-this-Designation-Job-Title-on-Top-da392082e2b24e11bbc67f6d6de2a825
// https://tall-nova-c74.notion.site/Ability-to-add-Designation-Job-Title-8a23de47bab14191873251e7bd142260

