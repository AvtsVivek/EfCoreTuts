using Ef000501_SubscriptionConsole.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Ef000501_SubscriptionConsole.Tests.IntegrationTests;

public class InMemorySubscriptionConsoleTests : CustomerProductBasicTests
{
  public InMemorySubscriptionConsoleTests() : base(
          new DbContextOptionsBuilder<SubscriptionContext>()
              .UseInMemoryDatabase("TestDatabase")
              .Options)
  {
    // Looks like in memory does not support sequences.
  }
}

public class InMemoryCustomerProductSubscriptionTests : CustomerProductSubscriptionTests
{
  public InMemoryCustomerProductSubscriptionTests() : base(
          new DbContextOptionsBuilder<SubscriptionContext>()
              .UseInMemoryDatabase("TestDatabase")
              .Options)
  {
    // Looks like in memory does not support sequences.
  }
}
