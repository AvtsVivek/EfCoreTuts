using Ef000501_SubscriptionConsole.DataAccess.Config;
using Ef000501_SubscriptionConsole.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ef000501_SubscriptionConsole.DataAccess;

public class SubscriptionContext : DbContext
{
  public SubscriptionContext(DbContextOptions<SubscriptionContext> options)
      : base(options)
  {
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new CustomerTypeConfiguration());
    modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
    modelBuilder.ApplyConfiguration(new TagTypeConfiguration());
    modelBuilder.ApplyConfiguration(new SubscriptionTypeConfiguration());
    // Instead of the above 4, I can use one line like this.
    // modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubscriptionContext).Assembly);
  }
  public DbSet<Customer> Customers { get; set; } = default!;
  public DbSet<Product> Products { get; set; } = default!;
  public DbSet<Subscription> Subscriptions { get; set; } = default!;
  public DbSet<Subscription> Tags { get; set; } = default!;
}
