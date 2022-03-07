using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ef000501_SubscriptionConsole.Commands;
using Ef000501_SubscriptionConsole.DataAccess;
using Ef000501_SubscriptionConsole.Domain;
using Ef000501_SubscriptionConsole.Domain.Services;
using Ef000501_SubscriptionConsole.Queries;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace Ef000501_SubscriptionConsole.Tests.IntegrationTests;

public abstract class CustomerProductSubscriptionTests
{
  protected DbContextOptions<SubscriptionContext> ContextOptions { get; }
  protected CustomerProductSubscriptionTests(DbContextOptions<SubscriptionContext> contextOptions)
  {

    ContextOptions = contextOptions;

    Seed();
  }

  private void Seed()
  {
    //using (var context = new SubscriptionContext(ContextOptions)) { }
  }

  [Fact]
  public async Task ThereShouldBeOneCustomerInTheDatabase()
  {
    using (var context = new SubscriptionContext(ContextOptions))
    {
      await context.Database.EnsureDeletedAsync();
      await context.Database.EnsureCreatedAsync();

      var product = new Product("Flowers", 10, BillingPeriod.Monthly);
      var customer = new Customer(new Email("customer@example.org"), new CustomerName("Hossam", "Barakat"));
      await context.Products.AddAsync(product);
      await context.Customers.AddAsync(customer);
      await context.SaveChangesAsync();

      var handler = new SubscribeRequestHandler(context, new SubscriptionAmountCalculator());
      await handler.Handle(new SubscribeRequest
      {
        CustomerId = customer.Id,
        ProductId = product.Id
      }, CancellationToken.None);

      var subscription = await context.Subscriptions
          .SingleOrDefaultAsync(x => x.Customer.Id == customer.Id && x.Product.Id == product.Id);
      subscription.Should().NotBeNull();

      await context.Database.EnsureDeletedAsync();
    }
  }

  // The above test is redundant. This is because, if the above fails, the below will also fail.
  // And if the below test passes, the above has to pass.

  [Fact]
  public async Task GetActiveSubscriptionsQueryRequestHandlerTest()
  {
    using (var context = new SubscriptionContext(ContextOptions))
    {
      await context.Database.EnsureDeletedAsync();
      await context.Database.EnsureCreatedAsync();

      var product = new Product("Flowers", 10, BillingPeriod.Monthly);
      var customer = new Customer(new Email("customer@example.org"), new CustomerName("Hossam", "Barakat"));
      await context.Products.AddAsync(product);
      await context.Customers.AddAsync(customer);
      await context.SaveChangesAsync();

      var handler = new SubscribeRequestHandler(context, new SubscriptionAmountCalculator());
      await handler.Handle(new SubscribeRequest
      {
        CustomerId = customer.Id,
        ProductId = product.Id
      }, CancellationToken.None);


      //Arange
      //var mediator = new Mock<IMediator>();
      var queryRequest = new GetActiveSubscriptionsQueryRequest() { CustomerId = customer.Id };

      var handler2 = new GetActiveSubscriptionsQueryRequestHandler(context);

      // Act
      var getActiveSubscriptionsResponse = await handler2.Handle(queryRequest, CancellationToken.None);

      //Asert
      getActiveSubscriptionsResponse.Should().NotBeNull();
      getActiveSubscriptionsResponse.Count.Should().Be(1);
      var subscription = getActiveSubscriptionsResponse.SingleOrDefault();
      subscription.Should().NotBeNull();
      subscription!.ProductName.Should().Be(product.Name);
      subscription!.BillingPeriod.Should().Be(BillingPeriod.Monthly.Name);

      await context.Database.EnsureDeletedAsync();
    }
  }
}
