using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ef000331_CustomerNestedOwnsMany.Tests.Integration;

public class SqlServerCustomerNestedOwnsManyBasicTests : CustomerNestedOwnsManyBasicTests
{
  public SqlServerCustomerNestedOwnsManyBasicTests()
      : base(new DbContextOptionsBuilder<CustomerContext>()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MeWurkCustomerOwnsMany").Options)
  { }
}

public abstract class CustomerNestedOwnsManyBasicTests
{
  protected DbContextOptions<CustomerContext> ContextOptions { get; }
  protected CustomerNestedOwnsManyBasicTests(DbContextOptions<CustomerContext> contextOptions)
  {
    ContextOptions = contextOptions;
    //Seed();
  }

  [Fact]
  public void CustomerWithNestedOwnsManyConfigurationCheck()
  {
    using (var companyContext = new CustomerContext(ContextOptions))
    {
      companyContext.Database.EnsureDeleted();
      companyContext.Database.EnsureCreated();
    }
  }

  [Fact]
  public void TestCustomerWithNestedOwnsMany()
  {
    using (var customerContext = new CustomerContext(ContextOptions))
    {
      customerContext.Database.EnsureDeleted();
      customerContext.Database.EnsureCreated();

      var expDate1 = new ExpirationDate();
      expDate1.SetExpirationDate(DateTime.Now, "Date 1");

      var expDate2 = new ExpirationDate();
      expDate2.SetExpirationDate(DateTime.Now, "Date 2");

      var expDate3 = new ExpirationDate();
      expDate3.SetExpirationDate(DateTime.Now, "Date 3");

      var expDate4 = new ExpirationDate();
      expDate4.SetExpirationDate(DateTime.Now, "Date 4");

      var expDateList1 = new List<ExpirationDate>() {
                    expDate1,
                    expDate2
                };

      var expDateList2 = new List<ExpirationDate>() {
                    expDate3,
                    expDate4
                };

      var status1 = new CustomerStatus();
      status1.SetExpirationDateAndStatus(expDateList1, "expiry Data List 1");

      var status2 = new CustomerStatus();
      status2.SetExpirationDateAndStatus(expDateList2, "expiry Data List 2");

      var statusList = new List<CustomerStatus>() {
                    status1,
                    status2
                };

      var customer = new Customer();
      customer.SetCustomerStatusAndName(statusList, "Vivek");

      customerContext.Add(customer);
      customerContext.SaveChanges();
    }

    using (var customerContext = new CustomerContext(ContextOptions))
    {
      var customer = customerContext.Set<Customer>().FirstOrDefault();

      customerContext.Remove(customer!);
      customerContext.SaveChanges();
    }

    using (var customerContext = new CustomerContext(ContextOptions))
    {
      var customer = customerContext.Set<Customer>();

      customer.Count().Should().Be(0);

      customerContext.Database.EnsureDeleted();
    }

  }


  private void PopulateDatabase(CustomerContext companyContext)
  {
    //var company_one = new Company("MeWurk");

    //var enggDept = new Department("Engg");

    ////enggDept.AddSubDepartments(new List<SubDepartment> {
    ////    new SubDepartment("Welding Shop", "Welding Mechanical Engg"),
    ////    new SubDepartment("Forging Shop", "Forging Mechanical Engg")
    ////});

    ////company_one.AddDepartments(new List<Department> {
    ////    enggDept
    ////});

    //companyContext.Add(company_one);

    //var company_two = new Company("MxWork");
    //companyContext.Add(company_two);
    //companyContext.SaveChanges();
  }

  private void Seed()
  {
    using (var companyContext = new CustomerContext(ContextOptions))
    {
      companyContext.Database.EnsureDeleted();
      companyContext.Database.EnsureCreated();

      PopulateDatabase(companyContext);
    }
  }
}
