using System;
using System.Reflection;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ef000101_BlogPostConsole.Test;

public abstract class BlogPostTest
{
  protected DbContextOptions<BloggingContext> ContextOptions { get; }
  protected BlogPostTest(DbContextOptions<BloggingContext> contextOptions)
  {
    ContextOptions = contextOptions;

    Seed();
  }

  private void Seed()
  {
    using (var context = new BloggingContext(ContextOptions))
    {
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      var blog = new Blog() { Url = "http://vivek.blog.mewurk.org" };
      var post = new Post()
      {
        //Id = 1,
        Blog = blog,
        Title = "My First Post",
        Content = "Hello World, This is my first post!!"
      };

      context.Add(blog);
      context.Add(post);
      context.SaveChanges();
    }
  }

  [Fact]
  public void PostInBlogShouldBeNullWithoutLazyLoading()
  {
    using (var context = new BloggingContext(ContextOptions))
    {
      context.ChangeTracker.LazyLoadingEnabled = false;
      var myBlog = context.Find<Blog>(1)!;

      var posts = GetInstanceField(typeof(Blog), myBlog, "Posts");
      posts.Should().BeNull("Because LazyLoadingEnabled is false");
      context.Database.EnsureDeleted();
    }
  }

  [Fact]
  public void PostInBlogShouldNotBeNullWithLazyLoading()
  {
    using (var context = new BloggingContext(ContextOptions))
    {
      context.ChangeTracker.LazyLoadingEnabled = true;
      var myBlog = context.Find<Blog>(1)!;

      var posts = GetInstanceField(typeof(Blog), myBlog, "Posts");
      posts.Should().NotBeNull("Because LazyLoadingEnabled is true");
      context.Database.EnsureDeleted();
    }
  }

  internal object GetInstanceField(Type type, object instance, string fieldName)
  {
    PropertyInfo prop = type.GetProperty("Posts", BindingFlags.NonPublic | BindingFlags.Instance)!;
    MethodInfo getter = prop.GetGetMethod(nonPublic: true)!;
    object posts = getter.Invoke(instance, null)!;
    return posts;
  }
}
