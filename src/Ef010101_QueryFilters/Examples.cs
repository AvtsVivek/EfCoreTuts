using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ef010101_QueryFilters;

public class Examples
{

  public static void RunFromSqlRawExample()
  {
    var inMemoryCollectionName = Guid.NewGuid().ToString();

    var options = new DbContextOptionsBuilder<SingleEntityContext>()
          .UseInMemoryDatabase(inMemoryCollectionName).Options;

    using var context = new SingleEntityContext(options);
    context.Database.EnsureCreated();

    var e1 = new SingleEntity { SoftDeleted = false };
    var e2 = new SingleEntity { SoftDeleted = true };
    context.AddRange(e1, e2);
    context.SaveChanges();

    var query = RelationalQueryableExtensions.FromSqlRaw(context.MyEntities, "SELECT * FROM MyEntities");
    var entities = query.ToList();

    //VERIFY
    var sql = query.ToQueryString();
    //_output.WriteLine(sql);
    var entityCount = entities.Count();

    Console.WriteLine(entityCount);
    //Console.WriteLine(entityCountFull);

  }

  public static void RunParentDependentExample()
  {
    var inMemoryCollectionName = Guid.NewGuid().ToString();

    var options = new DbContextOptionsBuilder<ParentDependentDbContext>()
          .UseInMemoryDatabase(inMemoryCollectionName).Options;

    using var context = new ParentDependentDbContext(options);
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

    var principal = context.Principals
        .Include(x => x.Dependents)
        .Single();

    var dependentCount = principal.Dependents.Count;

    Console.WriteLine(dependentCount);

  }
  public static void RunSingleEntityExample()
  {
    var inMemoryCollectionName = Guid.NewGuid().ToString();

    var options = new DbContextOptionsBuilder<SingleEntityContext>()
          .UseInMemoryDatabase(inMemoryCollectionName).Options;

    using var context = new SingleEntityContext(options);
    context.Database.EnsureCreated();

    var e1 = new SingleEntity { SoftDeleted = false };
    var e2 = new SingleEntity { SoftDeleted = true };
    context.AddRange(e1, e2);
    context.SaveChanges();

    context.ChangeTracker.Clear();
    var entityCount = context.MyEntities.Count();
    var entityCountFull = context.MyEntities.IgnoreQueryFilters().Count();

    Console.WriteLine(entityCount);
    Console.WriteLine(entityCountFull);
  }
}
