namespace Ef000501_SubscriptionConsole.SharedKernel;

public abstract class Entity
{
  public Guid Id { get; protected set; }

  private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
  public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

  protected void AddDomainEvent(IDomainEvent eventItem)
  {
    _domainEvents.Add(eventItem);
  }

  protected void RemoveDomainEvent(IDomainEvent eventItem)
  {
    _domainEvents?.Remove(eventItem);
  }

  public void ClearDomainEvents()
  {
    _domainEvents?.Clear();
  }
}
