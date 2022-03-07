using MeWurk.Hrms.CompanyOnboarding.Core.CompanyAggregate;
using MeWurk.Hrms.CompanyOnboarding.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeWurk.Hrms.CompanyOnboarding.Core.DataAccess;

public class OfficeTypeConfiguration : IEntityTypeConfiguration<Office>
{
  public void Configure(EntityTypeBuilder<Office> officeBuilder)
  {
    officeBuilder.Property(office => office.Name).HasMaxLength(Constants.OfficeNameLength);
    officeBuilder.Property(office => office.Type).HasMaxLength(Constants.OfficeTypeLength);
    officeBuilder.Property(office => office.TimeZone).HasMaxLength(Constants.OfficeTimeZoneLength);
    officeBuilder.Property(office => office.IsActive);

    var officeContactBuilder = officeBuilder.OwnsOne(office => office.Contact);
    officeContactBuilder.Property(officeContact => officeContact.Email).HasMaxLength(Constants.OfficeEmailLength).HasColumnName("Email");
    officeContactBuilder.Property(officeContact => officeContact.PhoneNumber).HasMaxLength(Constants.OfficePhoneNumberLength).HasColumnName("PhoneNumber");

    var officeLocationBuilder = officeBuilder.OwnsOne(office => office.Location);
    officeLocationBuilder.Property(officeLocation => officeLocation.Latitude).HasMaxLength(Constants.OfficeEmailLength).HasColumnName("LocationLatitude");
    officeLocationBuilder.Property(officeLocation => officeLocation.Logitude).HasMaxLength(Constants.OfficePhoneNumberLength).HasColumnName("LocationLongitude");
  }
}

public class EmployeeTypeConfiguration : IEntityTypeConfiguration<Employee>
{
  public void Configure(EntityTypeBuilder<Employee> employeeBuilder)
  {
    employeeBuilder.Property(employee => employee.EmployeeCode).HasMaxLength(Constants.OfficeNameLength);
    //officeBuilder.Property(office => office.Type).HasMaxLength(Constants.OfficeTypeLength);
    //officeBuilder.Property(office => office.TimeZone).HasMaxLength(Constants.OfficeTimeZoneLength);
    //officeBuilder.Property(office => office.IsActive);

    var employeeNameBuilder = employeeBuilder.OwnsOne(employee => employee.Name);
    employeeNameBuilder.Property(employeeName => employeeName.FirstName).HasMaxLength(Constants.OfficeEmailLength).HasColumnName("FirstName");
    employeeNameBuilder.Property(employeeName => employeeName.LastName).HasMaxLength(Constants.OfficePhoneNumberLength).HasColumnName("LastName");
    employeeNameBuilder.Property(employeeName => employeeName.Surname).HasMaxLength(Constants.OfficePhoneNumberLength).HasColumnName("SurName");

  }
}

public class DepartmentTypeConfiguration : IEntityTypeConfiguration<Department>
{
  public void Configure(EntityTypeBuilder<Department> departmentBuilder)
  {
    departmentBuilder.OwnsMany(company => company.SubDepartments, subDepartmentsBuilder =>
    {
      subDepartmentsBuilder.Property(subDepartment => subDepartment.Name).HasMaxLength(Constants.CompanySubDepartmentNameLength).IsRequired();
    });
  }
}
