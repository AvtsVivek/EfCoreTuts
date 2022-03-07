namespace Ef000301_RecordsConsole;

internal class Pie
{
  private Pie()
  {

  }

  public Guid Id { get; private set; }
  public string Name { get; private set; } = default!;
  public string Description { get; private set; } = default!;
  public ServingSize ServingSize { get; private set; } = default!;

  // Why do you need this?
  public static Pie Create(string name, string description, ServingSize servingSize)
  {
    if (string.IsNullOrEmpty(name))
    {
      throw new ArgumentNullException(nameof(name));
    }

    if (string.IsNullOrEmpty(description))
    {
      throw new ArgumentNullException(nameof(description));
    }

    return new Pie
    {
      Name = name,
      Description = description,
      ServingSize = servingSize
    };
  }

  public override string ToString()
  {
    return $"{Name} and its {Description} and its size is {ServingSize.minium} - {ServingSize.maxium}";
  }

}

// Records are value objects themselves.
public record ServingSize(int minium, int maxium) { }
