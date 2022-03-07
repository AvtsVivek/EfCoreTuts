using Microsoft.EntityFrameworkCore;

namespace Ef000321_CustomerNestedOwnsOne;

internal class Program
{
  private static void Main()
  {
    TestCustomer();
  }
  public static void TestCustomer()
  {
    var dbContextOptions = new DbContextOptionsBuilder<CustomerContext>()
        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CustomerNestedOwnsOne").Options;

    using (var customerContext = new CustomerContext(dbContextOptions))
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

    using (var customerContext = new CustomerContext(dbContextOptions))
    {
      var customer = customerContext.Set<Customer>().FirstOrDefault();

      customerContext.Database.EnsureDeleted();
    }
  }
}
