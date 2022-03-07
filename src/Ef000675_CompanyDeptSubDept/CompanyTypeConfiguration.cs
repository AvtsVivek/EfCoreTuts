using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ef000675_CompanyDeptSubDept;

public class CompanyTypeConfiguration : IEntityTypeConfiguration<Company>
{
  public void Configure(EntityTypeBuilder<Company> companyBuilder)
  {
    companyBuilder.Navigation(company => company.Departments).Metadata.SetField("_departments");
    companyBuilder.Navigation(company => company.Departments).UsePropertyAccessMode(PropertyAccessMode.Field);
    companyBuilder.OwnsMany(company => company.Departments, departmentsBuilder =>
    {
      departmentsBuilder.Property(department => department.Name).HasMaxLength(64).IsRequired();
      departmentsBuilder.OwnsMany(department => department.SubDepartments, subDepartment =>
              {

        });
    });
  }

  // Reference: 
  // 1. https://stackoverflow.com/q/70581121/1977871
}
