using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef000230_ProductRepo;

public class ProductService
{
  private readonly IProductRepository _productRepository;
  public ProductService(IProductRepository productRepository)
  {
    if (productRepository == null)
      throw new ArgumentNullException($"{nameof(productRepository)} is null");


    _productRepository = productRepository;
  }

  public Product GetProductById(int id)
  {
    return _productRepository.GetProductById(id);
  }
  public List<Product> GetProducts()
  {
    return _productRepository.GetProducts();
  }

  public List<Product> GetAvailableProducts()
  {
    var products = _productRepository.GetProducts();

    var availableProducts = products.Where(product => product.IsAvailable == true).ToList();

    if (availableProducts.Count == 0)
      throw new Exception("No Products are available");

    return availableProducts;
  }

}
