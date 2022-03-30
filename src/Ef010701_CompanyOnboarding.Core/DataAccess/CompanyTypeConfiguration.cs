using Ef010701_CompanyOnboarding.Core.CompanyAggregate;
using Ef010701_CompanyOnboarding.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ef010701_CompanyOnboarding.Core.DataAccess;

public class CompanyTypeConfiguration : IEntityTypeConfiguration<Company>
{
  public void Configure(EntityTypeBuilder<Company> companyBuilder)
  {
    companyBuilder.Property(company => company.Name).HasMaxLength(Constants.CompanyNameLength);

    companyBuilder.Property(company => company.SubDomain).HasMaxLength(Constants.CompanySubDomainLength);

    companyBuilder.Property(company => company.WebSite).HasMaxLength(Constants.CompanyWebsiteLength);

    companyBuilder.Property(company => company.Language).HasMaxLength(Constants.CompanyLanguageLength);

    companyBuilder.Property(company => company.ContactMobileNumber).HasMaxLength(Constants.CompanyContactMobileLength);

    companyBuilder.Property(company => company.ContactEmail).HasMaxLength(Constants.CompanyContactEmailLength);

    companyBuilder.Property(company => company.RegisteredCorporateOffice).HasMaxLength(Constants.CompanyRegisteredCorporateOfficeLength);

    var socialProfilesBuilder = companyBuilder.OwnsMany(company => company.SocialProfiles);
    companyBuilder.Navigation(company => company.SocialProfiles).Metadata.SetField("_socialProfiles");
    companyBuilder.Navigation(company => company.SocialProfiles).UsePropertyAccessMode(PropertyAccessMode.Field);
    socialProfilesBuilder.Property(socialProfile => socialProfile.Link).HasMaxLength(Constants.CompanySocialProfileLinkLength).IsRequired();
    socialProfilesBuilder.Property(socialProfile => socialProfile.Description).HasMaxLength(Constants.CompanySocialProfileDescriptionLength).IsRequired();

    var companyProfileWallpaperBuilder = companyBuilder.OwnsMany(company => company.CompanyProfileWallpapers);
    companyBuilder.Navigation(company => company.CompanyProfileWallpapers).Metadata.SetField("_companyProfileWallpapers");
    companyBuilder.Navigation(company => company.CompanyProfileWallpapers).UsePropertyAccessMode(PropertyAccessMode.Field);
    companyProfileWallpaperBuilder.Property(companyProfileWallpaper => companyProfileWallpaper.Name).HasMaxLength(Constants.CompanyProfileWallpaperNameLength).IsRequired();
    companyProfileWallpaperBuilder.Property(companyProfileWallpaper => companyProfileWallpaper.Description).HasMaxLength(Constants.CompanyProfileWallpaperDescriptionLength).IsRequired();
    companyProfileWallpaperBuilder.Property(companyProfileWallpaper => companyProfileWallpaper.WallpaperImage).HasMaxLength(Constants.CompanyProfileWallpaperImageByteLength).IsRequired();

    companyBuilder.Navigation(company => company.Departments).Metadata.SetField("_departments");
    companyBuilder.Navigation(company => company.Departments).UsePropertyAccessMode(PropertyAccessMode.Field);
    companyBuilder.OwnsMany(company => company.Departments, departmentsBuilder =>
    {
      departmentsBuilder.Property(department => department.Name).HasMaxLength(Constants.CompanyDepartmentNameLength).IsRequired();
      departmentsBuilder.Property(department => department.Description).HasMaxLength(Constants.CompanyDepartmentDescriptionLength).IsRequired();
      departmentsBuilder.OwnsMany(department => department.SubDepartments, subDepartmentBuilder =>
              {

              });
    });

    var companyProfileBuilder = companyBuilder.OwnsOne(x => x.CompanyProfile); //, nameBuilder =>
    companyProfileBuilder.Property(companyProfile => companyProfile.Heading).HasMaxLength(Constants.CompanyProfileHeadingLength).HasColumnName("Heading");
    companyProfileBuilder.Property(companyProfile => companyProfile.SubHeading).HasMaxLength(Constants.CompanyProfileSubHeadingLength).HasColumnName("SubHeading");
    companyProfileBuilder.Property(companyProfile => companyProfile.Link).HasMaxLength(Constants.CompanyProfileLinkLength).HasColumnName("Link");
    companyProfileBuilder.Property(companyProfile => companyProfile.Background).HasMaxLength(Constants.CompanyProfileBackgroundLength).HasColumnName("BackgroundImage");



    //companyBuilder.Property(company => company.OfficeType)
    //    .IsRequired()
    //    .HasMaxLength(Constants.OfficeTypeLength)
    //    .HasColumnName("OfficeType")
    //    .HasConversion(IndustryType => IndustryType.Name,
    //    name => OfficeType.FromName(name, true));
    //
    //companyBuilder.Property(company => company.IndustryType)
    //    .IsRequired()
    //    .HasMaxLength(Constants.IndustryTypeLength)
    //    .HasColumnName("IndustryType")
    //    .HasConversion(IndustryType => IndustryType.Name,
    //    name => IndustryType.FromName(name, true));
    //
    //companyBuilder.Property(company => company.CompanySize)
    //    .IsRequired()
    //    .HasMaxLength(Constants.CompanySizeLength)
    //    .HasColumnName("CompanySize")
    //    .HasConversion(IndustryType => IndustryType.Name,
    //    name => CompanySize.FromName(name, true));

  }
}
