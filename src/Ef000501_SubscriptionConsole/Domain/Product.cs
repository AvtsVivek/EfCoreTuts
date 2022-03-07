using Ef000501_SubscriptionConsole.SharedKernel;

namespace Ef000501_SubscriptionConsole.Domain;

public class Product : Entity
{
  private Product()
  {
  }
  public Product(string name, decimal amount, BillingPeriod billingPeriod) : this()
  {
    Id = Guid.NewGuid();
    Name = name ?? throw new ArgumentNullException(nameof(name));
    Amount = amount >= 0 ? amount : throw new ArgumentOutOfRangeException(nameof(amount));
    BillingPeriod = billingPeriod;
  }

  public string Name { get; private set; } = default!;
  public decimal Amount { get; private set; } = default!;
  public BillingPeriod BillingPeriod { get; private set; } = default!;

  private readonly List<Tag> _tags = new List<Tag>();
  public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();

  public void AddTag(Tag tag)
  {
    _tags.Add(tag);
  }
}
