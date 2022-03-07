using Microsoft.EntityFrameworkCore;

namespace Ef000331_CustomerNestedOwnsMany;

internal class Program
{
  private static void Main()
  {
    TestCustomer();
  }
  public static void TestCustomer()
  {
    var dbContextOptions = new DbContextOptionsBuilder<CustomerContext>()
        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CustomerNestedOwnsMany").Options;

    using (var customerContext = new CustomerContext(dbContextOptions))
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

    using (var customerContext = new CustomerContext(dbContextOptions))
    {
      var customer = customerContext.Set<Customer>().FirstOrDefault();

      customerContext.Database.EnsureDeleted();
    }
  }
}
