using Ef000501_SubscriptionConsole.DataAccess;
using Ef000501_SubscriptionConsole.Domain.Services;
using MediatR;

namespace Ef000501_SubscriptionConsole.Commands;

public class SubscribeRequest : IRequest
{
  public Guid CustomerId { get; set; }
  public Guid ProductId { get; set; }
}
public class SubscribeRequestHandler : IRequestHandler<SubscribeRequest>
{
  private readonly SubscriptionContext _subscriptionContext;
  private readonly ISubscriptionAmountCalculator _subscriptionAmountCalculator;

  public SubscribeRequestHandler(SubscriptionContext subscriptionContext, ISubscriptionAmountCalculator subscriptionAmountCalculator)
  {
    _subscriptionContext = subscriptionContext;
    _subscriptionAmountCalculator = subscriptionAmountCalculator;
  }
  public async Task<Unit> Handle(SubscribeRequest request, CancellationToken cancellationToken)
  {
    var customer = await _subscriptionContext.Customers.FindAsync(request.CustomerId);
    var product = await _subscriptionContext.Products.FindAsync(request.ProductId);

    customer!.AddSubscription(product!, _subscriptionAmountCalculator);

    await _subscriptionContext.SaveChangesAsync(cancellationToken);

    return Unit.Value;
  }
}
