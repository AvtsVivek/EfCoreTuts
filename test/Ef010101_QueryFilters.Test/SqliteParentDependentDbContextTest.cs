﻿using System;
using System.Data.Common;
using Ef010101_QueryFilters;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ef010101_QueryFilters.Test;

public class SqliteInMemoryParentDependentDbContextTest : ParentDependentDbContextTests, IDisposable
{
  private readonly DbConnection _connection = default!;

  public SqliteInMemoryParentDependentDbContextTest()
      : base(
          new DbContextOptionsBuilder<ParentDependentDbContext>()
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
