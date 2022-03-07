// See https://aka.ms/new-console-template for more information

using Ef010101_QueryFilters;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var inMemoryCollectionName = Guid.NewGuid().ToString();

var options = new DbContextOptionsBuilder<MyDbContext>()
      .UseInMemoryDatabase(inMemoryCollectionName).Options;

using var context = new MyDbContext(options);
context.Database.EnsureCreated();

var e1 = new MyEntity { SoftDeleted = false };
var e2 = new MyEntity { SoftDeleted = true };
context.AddRange(e1, e2);
context.SaveChanges();

context.ChangeTracker.Clear();
var entityCount = context.MyEntities.Count();
var entityCountFull = context.MyEntities.IgnoreQueryFilters().Count();

Console.WriteLine(entityCount);
Console.WriteLine(entityCountFull);
