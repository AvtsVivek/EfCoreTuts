using Ef000501_SubscriptionConsole.Services;
using Ef000501_SubscriptionConsole.SharedKernel;
using MediatR;

namespace Ef000501_SubscriptionConsole.Events;

public class CustomerSubscribedToProduct : IDomainEvent
{
  public Guid CustomerId { get; set; }
  public Guid ProductId { get; set; }
}
public class CustomerSubscribedToProductHandler : INotificationHandler<CustomerSubscribedToProduct>
{
  private readonly IEmailSender _emailSender;

  public CustomerSubscribedToProductHandler(IEmailSender emailSender)
  {
    _emailSender = emailSender;
  }
  public Task Handle(CustomerSubscribedToProduct notification, CancellationToken cancellationToken)
  {
    _emailSender.SendEmailAsync("Congratulations! You subscribed to a cool product");
    return Task.CompletedTask;
  }
}
