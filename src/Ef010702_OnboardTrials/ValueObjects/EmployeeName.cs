using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluralsightDdd.SharedKernel;

namespace Ef010702_OnboardTrials.ValueObjects;

public class EmployeeName : ValueObject
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Surname { get; private set; } = default!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
