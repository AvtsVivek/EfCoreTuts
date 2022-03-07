using Ef000501_SubscriptionConsole.Domain.Services;
using Ef000501_SubscriptionConsole.Events;
using Ef000501_SubscriptionConsole.SharedKernel;

namespace Ef000501_SubscriptionConsole.Domain;

public class Customer : Entity
{
  private Customer()
  {

  }

  public Customer(Email email, CustomerName customerName) : this()
  {
    Id = Guid.NewGuid();
    Email = email ?? throw new ArgumentNullException(nameof(email));
    CustomerName = customerName ?? throw new ArgumentNullException(nameof(customerName));
    _subscriptions = new List<Subscription>();
  }

  public Email Email { get; private set; } = default!;
  public CustomerName CustomerName { get; private set; } = default!;
  public decimal MoneySpent { get; private set; } = default!;
  private readonly List<Subscription> _subscriptions = default!;
  public IReadOnlyCollection<Subscription> Subscriptions => _subscriptions.AsReadOnly();

  public void AddSubscription(Product product, ISubscriptionAmountCalculator subscriptionAmountCalculator)
  {
    var subscriptionAmount = subscriptionAmountCalculator.Calculate(product, this);

    var subscription = new Subscription(this, product, subscriptionAmount);
    _subscriptions.Add(subscription);

    MoneySpent += subscription.Amount;

    AddDomainEvent(new CustomerSubscribedToProduct
    {
      CustomerId = Id,
      ProductId = product.Id
    });
  }
}
