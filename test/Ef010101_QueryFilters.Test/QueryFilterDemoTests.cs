using System;
using System.Linq;
using System.Reflection;
using Ef010101_QueryFilters;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ef010101_QueryFilters.Test;

public abstract class SingleEntityContextTests
{
  protected DbContextOptions<SingleEntityContext> ContextOptions { get; }
  protected SingleEntityContextTests(DbContextOptions<SingleEntityContext> contextOptions)
  {
    ContextOptions = contextOptions;

    Seed();
  }

  private void Seed()
  {

  }

  [Fact]
  public void SingleEntityContextTest()
  {
    using (var context = new SingleEntityContext(ContextOptions))
    {
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      //ATTEMPT
      var e1 = new SingleEntity { SoftDeleted = false };
      var e2 = new SingleEntity { SoftDeleted = true };
      context.AddRange(e1, e2);
      context.SaveChanges();

      //VERIFY
      context.ChangeTracker.Clear();
      context.MyEntities.Count().Should().Be(1);
      context.MyEntities.IgnoreQueryFilters().Count().Should().Be(2);
    }
  }
}
