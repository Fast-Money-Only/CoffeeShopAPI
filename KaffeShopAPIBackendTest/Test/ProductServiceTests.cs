using _Data;
using _Data.Repository;
using KaffeShopAPIBackendTest.FakeRepositories;
using Model;

namespace KaffeShopAPIBackendTest.Test;

[TestFixture]

public class ProductServiceTests
{
    private CoffeeShopContext _coffeeShopContext;
    private FakeProductRepository _repository;
    private ProductService _service;

    [SetUp]
    public void SetUp()
    {
        var options = DbTestOptionsClass.Create();
        _coffeeShopContext = new CoffeeShopContext(options);
        _repository = new FakeProductRepository(_coffeeShopContext);
        _service = new ProductService(_repository);

        Guid g = new Guid("81ace553-a5d3-4207-840d-3951bb207314");
        Guid prodNum = new Guid("06ba4325-3450-4b1e-993f-9df218b302b9");

        var product = new Product
        {
            ProductId = g,
            ProductName = "Coffee",
            ProductNumber = prodNum,
            Price = 200.0
        };

        _service.AddProduct(product);
    }

    [Test]
    public void CanGetProducts()
    {
        var actual = _service.GetProducts();
        Assert.That(actual.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void CanGetSpecificProduct()
    {
        Guid g = new Guid("81ace553-a5d3-4207-840d-3951bb207314");
        var prod = _service.GetProduct(g);
        
        Assert.AreEqual("Coffee", prod.ProductName);
    }

    [Test]
    public void CanAddProduct()
    {
        Guid prodId = new Guid("499db050-f9cf-45d5-b92a-ee8d8441e946");
        Guid prodNum = new Guid("c1b42bd9-5248-4540-a390-3711c5bbba3d");

        var expected = new Product
        {
            ProductId = prodId,
            ProductName = "Cream",
            ProductNumber = prodNum,
            Price = 150
        };

        _service.AddProduct(expected);
        var actual = _service.GetProduct(prodId);
        Assert.AreEqual(expected,actual);
    }
    
    [Test]
    public void CanDeleteProduct()
    {
        Guid g = new Guid("81ace553-a5d3-4207-840d-3951bb207314");
        var expected = _service.GetProduct(g);
        
        _service.DeleteProduct(g);
        Assert.That(_service.GetProducts(), Has.No.Member(expected));
    }
}