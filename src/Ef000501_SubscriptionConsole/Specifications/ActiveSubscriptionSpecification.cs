using Ef000501_SubscriptionConsole.Domain;
using Ef000501_SubscriptionConsole.Infrastructure;

namespace Ef000501_SubscriptionConsole.Specifications;

public class ActiveSubscriptionSpecification : BaseSpecification<Subscription>
{
  public ActiveSubscriptionSpecification()
  {
    Criteria = s => s.Status == SubscriptionStatus.Active;
  }
}

public static class ActiveSubscriptionSpecificationExtension
{
  public static IQueryable<Subscription> GetActiveSubscriptions(this IQueryable<Subscription> query)
  {
    return query.Where(new ActiveSubscriptionSpecification());
  }
}
