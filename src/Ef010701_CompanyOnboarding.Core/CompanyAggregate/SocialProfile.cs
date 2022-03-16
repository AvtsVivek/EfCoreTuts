using PluralsightDdd.SharedKernel;

namespace Ef010701_CompanyOnboarding.Core.CompanyAggregate;

// This should be a value object.
// https://tall-nova-c74.notion.site/Company-Profile-1d2a0d5a3ba347e9bee7912f48c8c646

public class SocialProfile : ValueObject
{

  public SocialProfile(string link, string description)
  {
    Link = link ?? throw new ArgumentNullException(nameof(link));
    Description = description; // Assuming that this is not manditory
  }

  public string Link { get; private set; }

  public string Description { get; private set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Link;
  }
}
