using System.Collections.Generic;
using System.Linq;
using Ef010101_QueryFilters;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ef010101_QueryFilters.Test;

public abstract class ParentDependentDbContextTests
{
  protected DbContextOptions<ParentDependentDbContext> ContextOptions { get; }
  protected ParentDependentDbContextTests(DbContextOptions<ParentDependentDbContext> contextOptions)
  {
    ContextOptions = contextOptions;

    Seed();
  }

  private void Seed()
  {

  }

  [Fact]
  public void ParentDependentTest()
  {
    using (var context = new ParentDependentDbContext(ContextOptions))
    {
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      var e1 = new Principal
      {
        Dependents = new List<Dependent>
            {
                new Dependent { SoftDeleted = false },
                new Dependent { SoftDeleted = true }
            }
      };

      context.Add(e1);
      context.SaveChanges();
      context.ChangeTracker.Clear();

      //ATTEMPT
      var principal = context.Principals
          .Include(x => x.Dependents)
          .Single();

      //VERIFY
      principal.Dependents.Count.Should().Be(1);
    }
  }
}
