using Ardalis.SmartEnum;

namespace Ef010701_OnboardTrials.CompanyAggregate;

// https://www.figma.com/proto/i7bDKtCGcihmJrMZQyUaBV/Signup?node-id=2%3A23788&scaling=min-zoom&page-id=0%3A1&starting-point-node-id=2%3A23788&show-proto-sidebar=1
public class CompanySize : SmartEnum<CompanySize>
{

    public static readonly CompanySize OneToFifty = new CompanySize("1 - 50", 1);
    public static readonly CompanySize FiftyToHundred = new CompanySize("51 - 100", 2);
    public static readonly CompanySize HundredToTwoFifty = new CompanySize("101 - 250", 3);
    public static readonly CompanySize TwoFiftyToFiveHundred = new CompanySize("251 - 500", 4);
    public static readonly CompanySize AboveFiveHundred = new CompanySize("Above 500", 5);


    private CompanySize(string name, int value) : base(name, value)
    { }
}
