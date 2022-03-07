using Ef000501_SubscriptionConsole.DataAccess;
using Ef000501_SubscriptionConsole.Specifications;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ef000501_SubscriptionConsole.Queries;

public class GetActiveSubscriptionsQueryRequest : IRequest<List<GetActiveSubscriptionsResponse>>
{
  public Guid CustomerId { get; set; }
}

public class GetActiveSubscriptionsResponse
{
  public string ProductName { get; set; } = default!;
  public string BillingPeriod { get; set; } = default!;
}

public class GetActiveSubscriptionsQueryRequestHandler
    : IRequestHandler<GetActiveSubscriptionsQueryRequest, List<GetActiveSubscriptionsResponse>>
{
  private readonly SubscriptionContext _context;

  public GetActiveSubscriptionsQueryRequestHandler(SubscriptionContext context)
  {
    _context = context;
  }
  public async Task<List<GetActiveSubscriptionsResponse>> Handle(GetActiveSubscriptionsQueryRequest request, CancellationToken cancellationToken)
  {
    var queryResult = await _context.Subscriptions
        .GetActiveSubscriptions()
        .ForCustomer(request.CustomerId)
        .Select(x => new GetActiveSubscriptionsResponse
        {
          ProductName = x.Product.Name,
          BillingPeriod = x.Product.BillingPeriod.ToString()
        })
        .ToListAsync(cancellationToken);
    return queryResult;
  }
}
