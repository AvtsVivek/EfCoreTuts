using Ef000501_SubscriptionConsole.SharedKernel;

namespace Ef000501_SubscriptionConsole.Domain;

public class Subscription : Entity
{
  private Subscription()
  {

  }
  public Subscription(Customer customer, Product product, decimal amount) : this()
  {
    Id = Guid.NewGuid();
    Customer = customer ?? throw new ArgumentNullException(nameof(customer));
    Product = product ?? throw new ArgumentNullException(nameof(product));
    Amount = amount >= 0 ? amount : throw new ArgumentOutOfRangeException(nameof(amount));
    Status = SubscriptionStatus.Active;
    CurrentPeriodEndDate = product.BillingPeriod.CalculateBillingPeriodEndDate();
  }
  public SubscriptionStatus Status { get; private set; } = default!;
  public Customer Customer { get; private set; } = default!;
  public Product Product { get; private set; } = default!;
  public decimal Amount { get; private set; } = default!;
  public DateTime CurrentPeriodEndDate { get; private set; } = default!;
}
