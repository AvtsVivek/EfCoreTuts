namespace Ef000303_PieBakeryConsole;

public class Pie
{
  private Guid _id;
  private string? _name;
  private List<Ingredient> _ingredients = new();
  private Pie() { }
  public Guid Id => _id;
  public string Name => _name!;
  public IReadOnlyCollection<Ingredient> Ingredients => _ingredients;

  public static Pie Create(string name) //, Portions portions, Category category)
  {
    if (string.IsNullOrEmpty(name))
      throw new ArgumentNullException(nameof(name));

    return new Pie
    {
      _id = Guid.NewGuid(),
      _name = name,
    };
  }

  public void UpdateIngredients(IEnumerable<Ingredient> ingredients)
  {
    _ingredients.Clear();
    _ingredients.AddRange(ingredients);
  }
}
