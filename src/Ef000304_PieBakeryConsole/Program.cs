using Microsoft.EntityFrameworkCore;

namespace Ef000304_PieBakeryConsole;

internal class Program
{
  private static void Main()
  {
    Console.WriteLine("This example is based on ");
    var options = new DbContextOptionsBuilder<MyContext>()
        .UseSqlite("datasource=db.sqlite")
        .Options;
    using var ctx = new MyContext(options);

    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
    ctx.Add(new Input
    {
      Boosters = {
                    new Booster { Index = 0 },
                    new Booster { Index = 1 }
                }
    }
    ); // no exception when the index > 0
    ctx.SaveChanges();
    ctx.Database.EnsureDeleted();
  }
}
public class MyContext : DbContext
{
  public MyContext(DbContextOptions options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Input>().OwnsMany(i => i.Boosters, b =>
    {
      b.HasKey("InputId", "Index");
      b.Property(b => b.Index).ValueGeneratedNever();
    });
  }
}

public class Input
{
  public int InputId { get; set; }
  public ICollection<Booster> Boosters { get; } = new List<Booster>();
}

public class Booster
{
  public int Index { get; set; }
}

//https://github.com/dotnet/efcore/issues/11162
// ValueGeneratedNever();
