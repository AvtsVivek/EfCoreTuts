using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ef010702_OnboardTrials.ValueObjects;
using PluralsightDdd.SharedKernel;

namespace Ef010702_OnboardTrials.CompanyAggregate;

public class Employee : BaseEntity<long>
{
    public EmployeeName Name { get; private set; } = default!;
    public string EmployeeCode { get; private set; } = default!;
    private readonly List<Team> _teams = new List<Team>();
    public IReadOnlyCollection<Team> Teams => _teams.AsReadOnly();
    public Designation Designation { get; private set; } = default!;
    public Grade Grade { get; private set; } = default!;
    public Office Office { get; private set; } = default!;
    public long CompanyId { get; private set; } = default!;

    public List<string> GetTeamNames()
    {
        return _teams.Select(team => team.Name).ToList();
    }
}
