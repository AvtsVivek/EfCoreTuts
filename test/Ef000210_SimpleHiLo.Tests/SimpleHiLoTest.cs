using System;
using System.Reflection;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;


// Ef000210_SimpleHiLo.Tests

namespace Ef000210_SimpleHiLo.Tests;

public abstract class SimpleHiLoTest
{
  protected DbContextOptions<AppDbContext> ContextOptions { get; }
  protected SimpleHiLoTest(DbContextOptions<AppDbContext> contextOptions)
  {

    ContextOptions = contextOptions;

    Seed();
  }

  private void Seed()
  {
    using (var context = new AppDbContext(ContextOptions))
    {
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      var employee1 = new Employee() { FirstName = "Vivek", LastName = "Koppula" };
      var employee2 = new Employee() { FirstName = "Vivek", LastName = "Koppula" };

      context.Add(employee1);
      context.Add(employee2);

      context.SaveChanges();
    }
  }

  [Fact]
  public void PostInBlogShouldBeNullWithoutLazyLoading()
  {
    using (var context = new AppDbContext(ContextOptions))
    {
      context.ChangeTracker.LazyLoadingEnabled = false;
      var employee1 = context.Find<Employee>(10);
      var employee2 = context.Find<Employee>(11);
      employee1.Should().NotBeNull();
      employee2.Should().NotBeNull();
      context.Database.EnsureDeleted();
    }
  }

  //[Fact]
  //public void PostInBlogShouldNotBeNullWithLazyLoading()
  //{
  //    using (var context = new BloggingContext(ContextOptions))
  //    {
  //        context.ChangeTracker.LazyLoadingEnabled = true;
  //        var myBlog = context.Find<Blog>(1);

  //        var posts = GetInstanceField(typeof(Blog), myBlog, "Posts");
  //        posts.Should().NotBeNull("Because LazyLoadingEnabled is true");
  //        context.Database.EnsureDeleted();
  //    }
  //}

  internal object GetInstanceField(Type type, object instance, string fieldName)
  {
    PropertyInfo prop = type.GetProperty("Posts", BindingFlags.NonPublic | BindingFlags.Instance)!;
    MethodInfo getter = prop.GetGetMethod(nonPublic: true)!;
    object posts = getter.Invoke(instance, null)!;
    return posts;
  }
}
