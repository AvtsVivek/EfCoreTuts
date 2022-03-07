namespace Ef000303_PieBakeryConsole;

public record Ingredient
{
  public Guid Id { get; private set; }
  public string Name { get; private set; }
  public Ingredient(string name)
  {
    if (string.IsNullOrEmpty(name))
      throw new ArgumentNullException(nameof(name));
    Name = name;
    Id = Guid.NewGuid();
  }
}
