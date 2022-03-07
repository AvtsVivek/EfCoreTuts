using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ef000321_CustomerNestedOwnsOne.Tests.Integration;

//public class SomeTestTemp
//{
//    [Fact]
//    public void TestCompany()
//    {
//        var dbContextOptions = new DbContextOptionsBuilder<CustomerContext>()
//            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CustomerNestedOwnsOne").Options;

//        using (var companyContext = new CustomerContext(dbContextOptions))
//        {
//            companyContext.Database.EnsureDeleted();
//            companyContext.Database.EnsureCreated();
//        }
//    }

//    [Fact]
//    public void TestCustomer()
//    {
//        var dbContextOptions = new DbContextOptionsBuilder<CustomerContext>()
//.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CustomerNestedOwnsOne").Options;

//        using (var customerContext = new CustomerContext(dbContextOptions))
//        {
//            customerContext.Database.EnsureDeleted();
//            customerContext.Database.EnsureCreated();

//            var expDate = new ExpirationDate();
//            expDate.SetExpirationDate(DateTime.Now, "Here we go..");

//            var status = new CustomerStatus();
//            status.SetExpirationDateAndStatus(expDate, "Ok");

//            var customer = new Customer();
//            customer.SetCustomerStatusAndName(status, "Vivek");

//            customerContext.Add(customer);
//            customerContext.SaveChanges();
//        }

//        using (var customerContext = new CustomerContext(dbContextOptions))
//        {
//            var customer = customerContext.Set<Customer>().FirstOrDefault();

//            customerContext.Database.EnsureDeleted();
//        }
//    }
//}
public class SqlServerCustomerNestedOwnsOneBasicTests : CustomerNestedOwnsOneBasicTests
{
  public SqlServerCustomerNestedOwnsOneBasicTests()
      : base(new DbContextOptionsBuilder<CustomerContext>()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MeWurkCustomerOwnsOne").Options)
  { }
}

public abstract class CustomerNestedOwnsOneBasicTests
{
  protected DbContextOptions<CustomerContext> ContextOptions { get; }
  protected CustomerNestedOwnsOneBasicTests(DbContextOptions<CustomerContext> contextOptions)
  {
    ContextOptions = contextOptions;
    //Seed();
  }

  [Fact]
  public void ConfigurationCheckTest()
  {
    using (var companyContext = new CustomerContext(ContextOptions))
    {
      companyContext.Database.EnsureDeleted();
      companyContext.Database.EnsureCreated();
    }
  }

  [Fact]
  public void TestCustomer()
  {
    using (var customerContext = new CustomerContext(ContextOptions))
    {
      customerContext.Database.EnsureDeleted();
      customerContext.Database.EnsureCreated();

      var expDate = new ExpirationDate();
      expDate.SetExpirationDate(DateTime.Now, "Here we go..");

      var status = new CustomerStatus();
      status.SetExpirationDateAndStatus(expDate, "Ok");

      var customer = new Customer();
      customer.SetCustomerStatusAndName(status, "Vivek");

      customerContext.Add(customer);
      customerContext.SaveChanges();
    }

    using (var customerContext = new CustomerContext(ContextOptions))
    {
      var customer = customerContext.Set<Customer>().FirstOrDefault();

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
