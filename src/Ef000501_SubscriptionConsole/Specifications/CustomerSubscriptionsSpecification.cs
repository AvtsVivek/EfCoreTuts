using Ef000501_SubscriptionConsole.Domain;
using Ef000501_SubscriptionConsole.Infrastructure;

namespace Ef000501_SubscriptionConsole.Specifications;

public class CustomerSubscriptionsSpecification : BaseSpecification<Subscription>
{
  public CustomerSubscriptionsSpecification(Guid customerId)
  {
    Criteria = s => s.Customer.Id == customerId;
  }
}
public static class CustomerSubscriptionsSpecificationExtension
{
  public static IQueryable<Subscription> ForCustomer(this IQueryable<Subscription> query, Guid customerId)
  {
    return query.Where(new CustomerSubscriptionsSpecification(customerId));
  }
}
