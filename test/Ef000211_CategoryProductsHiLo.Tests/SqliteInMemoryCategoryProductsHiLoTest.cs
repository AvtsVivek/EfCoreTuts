using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ef000211_CategoryProductsHiLo.Tests;

public class SqliteInMemoryCategoryProductsHiLoTest : CategoryProductsHiLoTest, IDisposable
{
  private readonly DbConnection _connection = default!;

  public SqliteInMemoryCategoryProductsHiLoTest() : base(new DbContextOptionsBuilder<AppDbContext>()
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
