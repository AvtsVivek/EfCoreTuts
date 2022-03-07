using System.Linq;
using Ef000501_SubscriptionConsole.Domain;
using Ef000501_SubscriptionConsole.Domain.Services;
using Ef000501_SubscriptionConsole.Events;
using FluentAssertions;
using Moq;
using Xunit;

namespace Ef000501_SubscriptionConsole.Tests.UnitTests;

public class CustmerSubscriptionTests
{

  [Theory]
  [InlineData(30, 30)]
  [InlineData(60, 60)]
  public void AddSubscriptionToCustomerShouldLeaveCustomerWithOneSubscription(decimal productPrice, decimal moneySpent)
  {

    // Arrange
    var vivekCustomerName = new CustomerName("Vivek", "Koppula");
    var vivekEmail = new Email("Vivek@MeWurk.com");
    var vivekCustomer = new Customer(vivekEmail, vivekCustomerName);
    var redRosesProduct = new Product("RedRoses", productPrice, BillingPeriod.Monthly);
    var subscriptionAmountCalculator = new Mock<ISubscriptionAmountCalculator>();
    subscriptionAmountCalculator.DefaultValue = DefaultValue.Mock;
    subscriptionAmountCalculator.Setup(c => c.Calculate(redRosesProduct, vivekCustomer)).Returns(productPrice);

    // Act
    vivekCustomer.AddSubscription(redRosesProduct, subscriptionAmountCalculator.Object);

    // Assert
    vivekCustomer.Subscriptions.Count.Should().Be(1);
    vivekCustomer.MoneySpent.Should().Be(moneySpent);
    vivekCustomer.DomainEvents.Count.Should().Be(1);
    var customerSubscribedToProductEvent = vivekCustomer.DomainEvents.Single() as CustomerSubscribedToProduct;
    customerSubscribedToProductEvent?.CustomerId.Should().Be(vivekCustomer.Id);
    customerSubscribedToProductEvent?.ProductId.Should().Be(redRosesProduct.Id);
  }
}
