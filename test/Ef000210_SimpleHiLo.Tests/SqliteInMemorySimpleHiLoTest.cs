using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ef000210_SimpleHiLo.Tests;

public class SqliteInMemorySimpleHiLoTest : SimpleHiLoTest, IDisposable
{
  private readonly DbConnection _connection = default!;

  public SqliteInMemorySimpleHiLoTest() : base(new DbContextOptionsBuilder<AppDbContext>()
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
