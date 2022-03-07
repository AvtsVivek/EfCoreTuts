using Ardalis.SmartEnum;

namespace MeWurk.Hrms.CompanyOnboarding.Core.CompanyAggregate;

public class OfficeType : SmartEnum<OfficeType>
{
  public static readonly OfficeType ResearchAndDevelopment = new OfficeType("Research & Development", 1);
  public static readonly OfficeType HeadQuarter = new OfficeType("Head Quarter", 2);
  public static readonly OfficeType Corporate = new OfficeType("Corporate", 3);
  public static readonly OfficeType ManufacturingUnit = new OfficeType("Manufacturing Unit", 4);
  public static readonly OfficeType Factory = new OfficeType("Factory", 5);
  public static readonly OfficeType Outlet = new OfficeType("Outlet", 6);
  public static readonly OfficeType Office = new OfficeType("Office", 7);
  public static readonly OfficeType Warehouse = new OfficeType("Warehouse", 8);
  public static readonly OfficeType Sales = new OfficeType("Sales", 9);
  public static readonly OfficeType Others = new OfficeType("Others", 10);


  private OfficeType(string name, int value) : base(name, value)
  { }
}
// Reference.
// https://tall-nova-c74.notion.site/Office-Type-a67bf29972224c1eae142edc50502f30
