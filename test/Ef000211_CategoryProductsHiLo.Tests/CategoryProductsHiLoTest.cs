using System;
using System.Reflection;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ef000211_CategoryProductsHiLo.Tests;

public abstract class CategoryProductsHiLoTest
{
  protected DbContextOptions<AppDbContext> ContextOptions { get; }
  protected CategoryProductsHiLoTest(DbContextOptions<AppDbContext> contextOptions)
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

      var category = new Category() { Name = "Some Category" };
      context.Categories.Add(category);

      var product = new Product { Name = "Some Product", CategoryId = category.Id };
      context.Products.Add(product);

      var category2 = new Category() { Name = "New Category" };
      context.Categories.Add(category2);

      var product2 = new Product { Name = "New Product", CategoryId = category2.Id };
      context.Products.Add(product2);

      context.SaveChanges();
    }

  }

  [Fact]
  public void PostInBlogShouldBeNullWithoutLazyLoading()
  {
    using (var context = new AppDbContext(ContextOptions))
    {
      context.ChangeTracker.LazyLoadingEnabled = false;
      var category1 = context.Find<Category>(10);
      var product1 = context.Find<Product>(10);
      category1.Should().NotBeNull();
      product1.Should().NotBeNull();
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
