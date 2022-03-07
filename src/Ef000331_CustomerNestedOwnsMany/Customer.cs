using Microsoft.EntityFrameworkCore;
using PluralsightDdd.SharedKernel;

namespace Ef000331_CustomerNestedOwnsMany;

public class Customer : BaseEntity<long>
{
  public Customer() { }
  public string Name { get; private set; } = default!;
  private Customer(List<CustomerStatus> customerStatuses, string name)
  {
    _statuses = customerStatuses;
    Name = name;
  }

  public void SetCustomerStatusAndName(List<CustomerStatus> customerStatuses, string name)
  {
    _statuses = customerStatuses;
    Name = name;
  }

  //public CustomerStatus Status { get; private set; }

  public List<CustomerStatus> _statuses = new List<CustomerStatus>();

  public IReadOnlyList<CustomerStatus> Statuses => _statuses.AsReadOnly();

}

public class CustomerStatus : ValueObject
{
  public string Status { get; private set; } = default!;
  public CustomerStatus()
  {

  }

  private CustomerStatus(List<ExpirationDate> expirationDateList, string status)
  {
    //ExpirationDate = expirationDate;
    _expirationDateList = expirationDateList;
    Status = status;
  }
  //public ExpirationDate? ExpirationDate { get; private set; }

  public List<ExpirationDate> _expirationDateList = new List<ExpirationDate>();

  public IReadOnlyList<ExpirationDate> ExpirationDateList => _expirationDateList.AsReadOnly();

  public void SetExpirationDateAndStatus(List<ExpirationDate> expirationDateList, string status)
  {
    _expirationDateList = expirationDateList;
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
      customer.OwnsMany(e => e.Statuses, status =>
              {
          status.OwnsMany(e => e.ExpirationDateList, expirationDate =>
                  {
                      //expirationDate.Property(e => e.Date).HasColumnName("StatusExpirationDate");
                    });
        });
    });
  }
}
