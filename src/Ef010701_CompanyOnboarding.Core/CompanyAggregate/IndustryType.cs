using Ardalis.SmartEnum;

namespace MeWurk.Hrms.CompanyOnboarding.Core.CompanyAggregate;

public class IndustryType : SmartEnum<IndustryType>
{

  public static readonly IndustryType Agriculture = new IndustryType("Agriculture", 1);
  public static readonly IndustryType Manufacturing = new IndustryType("Manufacturing", 2);
  public static readonly IndustryType Services = new IndustryType("Services", 3);
  public static readonly IndustryType SoftwareIndustry = new IndustryType("Software Industry", 4);
  public static readonly IndustryType Restaurant = new IndustryType("Restaurant", 5);

  private IndustryType(string name, int value) : base(name, value)
  { }


  //private readonly Func<DateTime> _endDateCalculation;
  //private CompanyType(string name, int value, Func<DateTime> endDateCalculation) : base(name, value)
  //{
  //    _endDateCalculation = endDateCalculation;
  //}
  //public DateTime CalculateBillingPeriodEndDate()
  //{
  //    return _endDateCalculation();
  //}
}
