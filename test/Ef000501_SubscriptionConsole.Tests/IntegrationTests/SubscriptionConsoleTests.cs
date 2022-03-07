using System;
using System.Reflection;
using System.Threading.Tasks;
using Ef000501_SubscriptionConsole.DataAccess;
using Ef000501_SubscriptionConsole.Domain;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace Ef000501_SubscriptionConsole.Tests.IntegrationTests;

public abstract class CustomerProductBasicTests
{
  protected DbContextOptions<SubscriptionContext> ContextOptions { get; }
  protected CustomerProductBasicTests(DbContextOptions<SubscriptionContext> contextOptions)
  {

    ContextOptions = contextOptions;

    Seed();
  }

  private void Seed()
  {
    using (var context = new SubscriptionContext(ContextOptions))
    {
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      var vivekCustomerName = new CustomerName("Vivek", "Koppula");
      var vivekEmail = new Email("Vivek@MeWurk.com");

      var vivekCustomer = new Customer(vivekEmail, vivekCustomerName);
      context.Add(vivekCustomer);

      var redRoses = new Product("RedRoses", 30, BillingPeriod.Monthly);
      context.Add(redRoses);

      context.SaveChanges();
    }
  }

  [Fact]
  public async Task ThereShouldBeOneCustomerInTheDatabase()
  {
    using (var context = new SubscriptionContext(ContextOptions))
    {
      //context.ChangeTracker.LazyLoadingEnabled = false;
      var customers = await context.Customers.ToListAsync();
      customers.Count.Should().Be(1);
      var customer = customers[0];

      customer.CustomerName.FirstName.Should().Be("Vivek");
      customer.CustomerName.LastName.Should().Be("Koppula");
      customer.Email.Value.Should().Be("Vivek@MeWurk.com");

      context.Database.EnsureDeleted();
    }
  }

  [Fact]
  public async Task ThereShouldBeOneProductInTheDatabase()
  {
    using (var context = new SubscriptionContext(ContextOptions))
    {
      var products = await context.Products.ToListAsync();
      products.Count.Should().Be(1);
      var product = products[0];

      product.Name.Should().Be("RedRoses");
      product.Amount.Should().Be(30);
      product.BillingPeriod.Value.Should().Be(BillingPeriod.Monthly.Value);
      product.BillingPeriod.Name.Should().Be(BillingPeriod.Monthly.Name);
      product.BillingPeriod.Should().Be(BillingPeriod.Monthly);

      context.Database.EnsureDeleted();
    }
  }


  internal object GetInstanceField(Type type, object instance, string fieldName)
  {
    var prop = type.GetProperty("Posts", BindingFlags.NonPublic | BindingFlags.Instance)!;
    var getter = prop.GetGetMethod(nonPublic: true)!;
    var posts = getter.Invoke(instance, null)!;
    return posts;
  }
}
