namespace Ef000230_ProductRepo;

public class ProductRepository : IProductRepository
{
  public List<Product> Products { get; set; } = default!;

  public ProductRepository()
  {
    Products = new List<Product> {
      new Product {
        Id = 1,
        Name = "Computer",
        IsAvailable = true,
      },
      new Product {
        Id=2,
        Name = "Laptop",
        IsAvailable=false,
      }
    };
  }

  public ProductRepository(List<Product> products)
  {
    Products = products;
  }
  public Product GetProductById(int id)
  {
    var product = GetProducts().Where(product => product.Id == id).FirstOrDefault();
    return product!;
  }
  public List<Product> GetProducts()
  {
    return Products;
  }
}
