using Ef000501_SubscriptionConsole.SharedKernel;

namespace Ef000501_SubscriptionConsole.Domain;

public class Tag : Entity
{
  private Tag()
  {

  }
  public Tag(string name) : this()
  {
    Id = Guid.NewGuid();
    Name = name;
  }

  public string Name { get; private set; } = default!;
  private readonly List<Product> _products = new List<Product>();
  public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
}
