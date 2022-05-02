using PluralsightDdd.SharedKernel;

namespace Ef010702_OnboardTrials.CompanyAggregate;

public class CompanyProfile : ValueObject
{
    public CompanyProfile(string heading, string subHeading, string link, /*string preview, */ byte[] background)
    {
        //Heading = heading ?? throw new ArgumentNullException(nameof(heading));
        Heading = heading;

        SubHeading = subHeading; // Assuming that this is not manditory

        //Link = link ?? throw new ArgumentNullException(nameof(link));

        Link = link;
        //Preview = preview ?? throw new ArgumentNullException(nameof(preview));

        //Background = background ?? throw new ArgumentNullException(nameof(background));

        Background = background;
    }
    public string? Heading { get; private set; } = default!;
    public string? SubHeading { get; private set; } = default!;
    public string? Link { get; private set; } = default!;
    //public string Preview { get; private set; }
    public byte[]? Background { get; private set; } = default!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        //throw new NotImplementedException();

        yield return Heading!;
        yield return SubHeading!;
        yield return Link!;
        yield return Background!;
    }
}
