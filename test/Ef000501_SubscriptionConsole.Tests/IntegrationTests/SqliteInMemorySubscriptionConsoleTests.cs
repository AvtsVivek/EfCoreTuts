using System;
using System.Data.Common;
using Ef000501_SubscriptionConsole.DataAccess;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ef000501_SubscriptionConsole.Tests.IntegrationTests;

public class SqliteInMemoryCustomerProductBasicTests : CustomerProductBasicTests, IDisposable
{
  private readonly DbConnection _connection = default!;

  public SqliteInMemoryCustomerProductBasicTests() : base(new DbContextOptionsBuilder<SubscriptionContext>()
      .UseSqlite(CreateInMemoryDatabase()).Options)
  {
    _connection = RelationalOptionsExtension.Extract(ContextOptions).Connection!;
  }

  private static DbConnection CreateInMemoryDatabase()
  {
    var connection = new SqliteConnection("Filename=:memory:");

    connection.Open();

    return connection;
  }

  public void Dispose() => _connection.Dispose();
}

public class SqliteInMemoryCustomerProductSubscriptionTests : CustomerProductSubscriptionTests, IDisposable
{
  private readonly DbConnection _connection = default!;

  public SqliteInMemoryCustomerProductSubscriptionTests() : base(new DbContextOptionsBuilder<SubscriptionContext>()
      .UseSqlite(CreateInMemoryDatabase()).Options)
  {
    _connection = RelationalOptionsExtension.Extract(ContextOptions).Connection!;
  }

  private static DbConnection CreateInMemoryDatabase()
  {
    var connection = new SqliteConnection("Filename=:memory:");

    connection.Open();

    return connection;
  }

  public void Dispose() => _connection.Dispose();
}
