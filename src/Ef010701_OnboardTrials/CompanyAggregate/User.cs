using PluralsightDdd.SharedKernel;

namespace Ef010701_OnboardTrials.CompanyAggregate;

// Should this be Guid, or long. Need to find out.
// Is GoogleId and LinkedInIn needed here?
public class User : BaseEntity<Guid>
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Phone { get; private set; } = default!;
    public string GoogleId { get; private set; } = default!;
    public string LinkedInId { get; private set; } = default!;
}
