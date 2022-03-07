namespace Ef000230_ProductRepo;

public interface IProductRepository
{
  public Product GetProductById(int id);

  public List<Product> GetProducts();

}
