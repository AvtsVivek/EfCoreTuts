using Microsoft.EntityFrameworkCore;
using PluralsightDdd.SharedKernel;

namespace Ef000321_CustomerNestedOwnsOne;

public class Customer : BaseEntity<long>
{
  public Customer() { }
  public string Name { get; private set; } = default!;
  private Customer(CustomerStatus customerStatus, string name)
  {
    Status = customerStatus;
    Name = name;
  }

  public void SetCustomerStatusAndName(CustomerStatus customerStatus, string name)
  {
    Status = customerStatus;
    Name = name;
  }
  public CustomerStatus Status { get; private set; } = default!;
}

public class CustomerStatus : ValueObject
{
  public string Status { get; private set; } = default!;
  public CustomerStatus()
  {

  }

  private CustomerStatus(ExpirationDate expirationDate, string status)
  {
    ExpirationDate = expirationDate;
    Status = status;
  }
  public ExpirationDate? ExpirationDate { get; private set; }

  public void SetExpirationDateAndStatus(ExpirationDate expirationDate, string status)
  {
    ExpirationDate = expirationDate;
    Status = status;
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Status;
  }
}

public class ExpirationDate : ValueObject
{
  public string ExpDate { get; private set; } = default!;
  public ExpirationDate()
  {

  }
  private ExpirationDate(DateTime dateTime, string expDate)
  {
    Date = dateTime;
    ExpDate = expDate;
  }

  public void SetExpirationDate(DateTime dateTime, string expDate)
  {
    Date = dateTime;
    ExpDate = expDate;
  }

  public DateTime? Date { get; private set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Date!;
  }
}

public class CustomerContext : DbContext
{
  public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Customer>(customer =>
    {
      customer.OwnsOne(e => e.Status, status =>
              {
          status.OwnsOne(e => e.ExpirationDate, expirationDate =>
                  {
                      //expirationDate.Property(e => e.Date).HasColumnName("StatusExpirationDate");
                    });
        });
    });
  }
}
