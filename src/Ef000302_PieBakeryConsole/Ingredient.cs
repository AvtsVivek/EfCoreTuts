namespace Ef000302_PieBakeryConsole;

public record Ingredient
{
  public Guid Id { get; private set; }
  public string Name { get; private set; } // Why not init
  public bool IsAllergen { get; private set; } // Why not init
  public double RelativeAmount { get; private set; } // Why not init

  public Ingredient(string name, bool isAllergen, double relativeAmount)
  {
    if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
    if (relativeAmount > 1.0 || relativeAmount <= 0.0) throw new ArgumentOutOfRangeException(nameof(relativeAmount));
    Id = Guid.NewGuid();
    Name = name;
    IsAllergen = isAllergen;
    RelativeAmount = relativeAmount;
  }
}
