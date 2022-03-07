using PluralsightDdd.SharedKernel;
using PluralsightDdd.SharedKernel.Interfaces;

namespace MeWurk.Hrms.CompanyOnboarding.Core.CompanyAggregate;

// This is based on the following
// https://tall-nova-c74.notion.site/Company-Profile-30dc757df583404991e645a7e4939170
// https://tall-nova-c74.notion.site/Epic-6-As-an-Owner-Admin-HR-I-want-to-add-my-company-s-data-in-detail-which-can-be-further-u-64cd5bdb40a74e3a88edf25bf0bec137?p=30dc757df583404991e645a7e4939170

public class Company : BaseEntity<long>, IAggregateRoot
{
  //private readonly List<User> _users = new List<User>();
  private readonly List<SocialProfile> _socialProfiles = new List<SocialProfile>();
  private readonly List<CompanyProfileWallpaper> _companyProfileWallpapers = new List<CompanyProfileWallpaper>();
  //private readonly List<Department> _departments = new List<Department>();
  //private readonly List<Office> _offices = new List<Office>();

  private Company() { }

  public Company(string name, string subDomain, string industryType, List<SocialProfile> socialProfiles,
      string officeType, string companySize)
  {
    Name = name;
    SubDomain = subDomain;
    IndustryType = industryType;
    _socialProfiles = socialProfiles;

    //if (officeType == null)
    //  OfficeType = "Corporate";
    //else
    //  OfficeType = officeType;

    if (companySize == null)
      CompanySize = "1 - 50";
    else
      CompanySize = companySize;

  }

  //public Company(string name, string subDomain, IndustryType industryType, List<SocialProfile> socialProfiles,
  //    OfficeType officeType = null!, CompanySize companySize = null!)
  //{
  //    //Name = name;
  //    //SubDomain = subDomain;
  //    //IndustryType = industryType;
  //    //_socialProfiles = socialProfiles;
  //
  //    //if (officeType == null)
  //    //    OfficeType = OfficeType.HeadQuarter;
  //
  //    //if (companySize == null)
  //    //    CompanySize = CompanySize.OneToFifty;
  //
  //}

  //public void AddDepartments(List<Department> departments)
  //{
  //  if (departments.Count == 0)
  //    throw new ArgumentException("Department argument has 0 count");

  //  // Add any business rules regarding departments here.

  //  if (_departments.Count == 0)
  //    _departments.AddRange(departments);
  //  else
  //    throw new Exception($"Currently this is not yet implimented. " +
  //        $"This needs to be enhanced.");
  //}


  public string SubDomain { get; private set; } = default!;
  public string Name { get; private set; } = default!;
  public string? WebSite { get; private set; } = default!;
  public string TenantId { get; private set; } = default!; // Should this be called customer id,
  public string Language { get; private set; } = "English"; // Hardcoded to English currently, till MVP

  // It will be pre-filled from Sign up page
  // Will this be different from signed up users mobile number?
  public string? ContactMobileNumber { get; private set; } = default!;
  // Will this be different from signed up users email id?
  public string? ContactEmail { get; private set; } = default!;

  public string? RegisteredCorporateOffice { get; private set; } = default!;

  //// The following should be a value object.
  //// We need to create a new type for the social profile like with at least two fields, 
  //// Social profile link, and description.
  //// This mapping will be similar to pie and ingredients mapping.
  public IReadOnlyCollection<SocialProfile> SocialProfiles => _socialProfiles.AsReadOnly();
  public IReadOnlyCollection<CompanyProfileWallpaper> CompanyProfileWallpapers => _companyProfileWallpapers.AsReadOnly();
  //public IReadOnlyCollection<Department> Departments => _departments.AsReadOnly();
  //public IReadOnlyCollection<Office> Offices => _offices.AsReadOnly();

  public CompanyProfile CompanyProfile { get; private set; } = default!;

  // It will be pre-selected from Sign up page
  // https://tall-nova-c74.notion.site/Company-Profile-30dc757df583404991e645a7e4939170
  // This needs to be modeled as a drop down.
  // This should be similar to the following billing period in the Product entity of Subscription example.
  // public BillingPeriod BillingPeriod { get; private set; }
  // So the EF Core configuration would look like the following
  // builder.Property(x => x.BillingPeriod).IsRequired()
  // .HasColumnName("BillingPeriod").
  // HasConversion(period => period.Name, name => BillingPeriod.FromName(name, true));
  //public IndustryType IndustryType { get; private set; } = IndustryType.Services;
  //public CompanySize CompanySize { get; private set; } = CompanySize.OneToFifty;
  //public OfficeType OfficeType { get; private set; } = OfficeType.Corporate;
  public string IndustryType { get; private set; } = default!;
  public string CompanySize { get; private set; } = default!;

  // Need to remote this from here.
  // Office Type will be part of office.
  //public string OfficeType { get; private set; } = default!;
}
