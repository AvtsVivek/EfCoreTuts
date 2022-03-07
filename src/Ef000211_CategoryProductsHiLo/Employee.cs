namespace Ef000211_CategoryProductsHiLo;

public class Category
{
  public int Id { get; set; }

  public string Name { get; set; } = default!;

  public ICollection<Product> Products { get; set; } = default!;
}
