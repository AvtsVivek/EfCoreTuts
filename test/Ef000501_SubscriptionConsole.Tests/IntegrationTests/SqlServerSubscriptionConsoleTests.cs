using Ef000501_SubscriptionConsole.DataAccess;
using Microsoft.EntityFrameworkCore;


namespace Ef000501_SubscriptionConsole.Tests.IntegrationTests;

public class SqlServerSubscriptionConsoleTests : CustomerProductBasicTests
{
  public SqlServerSubscriptionConsoleTests()
      : base(new DbContextOptionsBuilder<SubscriptionContext>()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DddSubscriptionTest;Trusted_Connection=True")
            .Options)
  {

  }
}

//CustomerProductSubscriptionTests

public class SqlServerCustomerProductSubscriptionTests : CustomerProductSubscriptionTests
{
  public SqlServerCustomerProductSubscriptionTests()
      : base(new DbContextOptionsBuilder<SubscriptionContext>()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DddSubscriptionTest;Trusted_Connection=True")
            .Options)
  {

  }
}
