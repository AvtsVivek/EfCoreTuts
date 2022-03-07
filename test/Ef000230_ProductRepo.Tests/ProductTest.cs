using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System;
using Moq;
using Ef000230_ProductRepo;

namespace Ef000230_ProductRepo.Tests;

public class ProductTest
{
  [Fact]
  public void NumberOfProductsMustBeTwo()
  {

    // Arrange
    //var sut = new ProductService(productRepository);
    var sut = new ProductRepository();

    // Act
    var products = sut.GetProducts();

    // Assert
    products.Count.Should().Be(2);
  }

  [Fact]
  public void EnsureExceptionIsThrownWhenThereAreNoProducts()
  {
    // Arrange
    var products = new List<Product>();
    var productRepository = new ProductRepository(products);
    var sut = new ProductService(productRepository);

    // Act
    //var products = sut.GetAvailableProducts();
    Action act = () => sut.GetAvailableProducts();


    // Assert
    act.Should().Throw<Exception>()
        //.WithInnerException<ArgumentException>()
        .WithMessage("No Products are available");
  }

  [Fact]
  public void EnsureExceptionIsThrownWhenThereAreNoAvailableProducts()
  {
    // Arrange
    var products = new List<Product> {
      new Product {
        Id = 1,
        Name = "Computer",
        IsAvailable = false,
      },
      new Product {
        Id=2,
        Name = "Laptop",
        IsAvailable=false,
      }
    };

    var productRepository = new ProductRepository(products);
    var sut = new ProductService(productRepository);

    // Act
    //var products = sut.GetAvailableProducts();
    Action getProducts = () => sut.GetAvailableProducts();

    // Assert
    getProducts.Should().Throw<Exception>()
      //.WithInnerException<ArgumentException>()
      .WithMessage("No Products are available");
  }

  [Fact]
  public void EnsureExceptionIsThrownWhenThereAreNoAvailableProductsWithMoq()
  {
    // Arrange
    var mockProductRepository = new Mock<IProductRepository>();

    var products = new List<Product> {
      new Product {
        Id = 1,
        Name = "Computer",
        IsAvailable = false,
      },
      new Product {
        Id=2,
        Name = "Laptop",
        IsAvailable=false,
      }
    };

    mockProductRepository.Setup(productRepository => productRepository.GetProducts())
      .Returns(products);

    var sut = new ProductService(mockProductRepository.Object);

    // Act
    //var products = sut.GetAvailableProducts();
    Action act = () => sut.GetAvailableProducts();


    // Assert
    act.Should().Throw<Exception>()
        //.WithInnerException<ArgumentException>()
        .WithMessage("No Products are available");
  }

}
