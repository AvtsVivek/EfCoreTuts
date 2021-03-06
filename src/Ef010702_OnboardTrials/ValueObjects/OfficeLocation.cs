using PluralsightDdd.SharedKernel;

namespace Ef010702_OnboardTrials.ValueObjects;

public class OfficeLocation : ValueObject
{
    // Not clear how to model this one.
    // For now I am using latitude and longitude
    // We need to a simple r n d with google api
    public float Latitude { get; private set; }
    public float Logitude { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return new object[] { Latitude, Logitude };
    }
}
