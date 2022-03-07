namespace Ef000302_PieBakeryConsole;

public class Pie
{
  private Guid _id;
  private string? _name;
  private string? _description;
  private Portions? _portions;
  private List<Ingredient> _ingredients = new();


  private Pie()
  {

  }

  public Guid Id => _id;
  public string Name => _name!;
  public string Description => _description!;
  public Portions Portions => _portions!;
  public IReadOnlyCollection<Ingredient> Ingredients => _ingredients; // Need to add .AsReadOnly() But will do it after unit tests

  // For me its not clear whats better of the following two.
  // 1. Have a CategoryId // public Guid CategoryId { get; private set; }
  // Or
  // 2. Have a navigation property. public Category Category { get; private set; }

  // If we have navigation property, then there is nothing more is required.
  // You dont have to add any further configuration.
  // builder.HasOne<Category>().WithMany();
  // But on the other hand, if you choose option 1, 
  // Have a CategoryId // public Guid CategoryId { get; private set; }
  // Then, we need like this
  // builder.HasOne<Category>().WithMany().HasForeignKey(x => x.CategoryId);

  //public Guid CategoryId { get; private set; }
  public Category Category { get; private set; } = default!;

  public static Pie Create(string name, string description, Portions portions, Category category)
  {
    if (string.IsNullOrEmpty(name))
    {
      throw new ArgumentNullException(nameof(name));
    }

    if (string.IsNullOrEmpty(description))
    {
      throw new ArgumentNullException(nameof(description));
    }

    if (portions == null)
    {
      throw new ArgumentNullException(nameof(portions));
    }

    return new Pie
    {
      _id = Guid.NewGuid(),
      _name = name,
      _description = description,
      _portions = portions,
      Category = category

    };
  }

  public void UpdateIngredients(IEnumerable<Ingredient> ingredients)
  {
    if (ingredients == null)
    {
      throw new ArgumentNullException(nameof(ingredients));
    }

    if (!ingredients.Any())
    {
      throw new ArgumentException("Must specify at least one ingredient.", nameof(ingredients));
    }

    if (ingredients.Sum(x => x.RelativeAmount) != 1.0)
    {
      throw new ArgumentException("The relative amount of all ingredients combined must add up to 1.0");
    }

    _ingredients.Clear();
    _ingredients.AddRange(ingredients);
  }
}
