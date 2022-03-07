using System;
using System.Data.Common;
using Items;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ItemsWebApi.Tests;
public class SqliteInMemoryItemsControllerTest : ItemsControllerTest, IDisposable
{
  private readonly DbConnection _connection = default!;

  public SqliteInMemoryItemsControllerTest()
      : base(
          new DbContextOptionsBuilder<ItemsContext>()
              .UseSqlite(CreateInMemoryDatabase())
              .Options)
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
