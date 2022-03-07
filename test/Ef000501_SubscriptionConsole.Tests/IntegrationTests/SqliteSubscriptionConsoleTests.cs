using Ef000501_SubscriptionConsole.DataAccess;
using Microsoft.EntityFrameworkCore;


namespace Ef000501_SubscriptionConsole.Tests.IntegrationTests;

public class SqliteSubscriptionConsoleTests : CustomerProductBasicTests
{
  public SqliteSubscriptionConsoleTests()
      : base(new DbContextOptionsBuilder<SubscriptionContext>()
              .UseSqlite("Filename=Test.db").Options)
  {

  }
}

//CustomerProductSubscriptionTests

public class SqliteCustomerProductSubscriptionTests : CustomerProductSubscriptionTests
{
  public SqliteCustomerProductSubscriptionTests()
      : base(new DbContextOptionsBuilder<SubscriptionContext>()
              .UseSqlite("Filename=Test.db").Options)
  {

  }
}
