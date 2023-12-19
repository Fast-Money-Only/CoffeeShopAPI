using _Data;
using _Data.Repository;
using KaffeShopAPIBackendTest.FakeRepositories;
using Model;

namespace KaffeShopAPIBackendTest.Test;

[TestFixture]

public class CakeServiceTests
{
    private CoffeeShopContext _coffeeShopContext;
    private FakeCakeRepository _repository;
    private CakeService _service;

    [SetUp]
    public void SetUp()
    {
        var options = DbTestOptionsClass.Create();
        _coffeeShopContext = new CoffeeShopContext(options);
        _repository = new FakeCakeRepository(_coffeeShopContext);
        _service = new CakeService(_repository);

        Guid g = new Guid("f72751a3-d450-48b2-bcf1-d081ea204a79");

        var testCake = new Cake
        {
            Id = g,
            Name = "Drømmekage",
            Price = 12.5
        };

        _service.CreateCake(testCake);
    }

    [Test]
    public void CanSeeCakes()
    {
        var actual = _service.GetCakes();
        Assert.That(actual.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void CanGetSpecificCake()
    {
        Guid g = new Guid("f72751a3-d450-48b2-bcf1-d081ea204a79");
        var actual = _service.GetCake(g);
        Assert.AreEqual("Drømmekage", actual.Name);
    }
    
    [Test]
    public void CanCreateCake()
    {
        Guid cakeId = new Guid("a12abe52-923d-495e-ab41-571662b77e45");
        var testCake = new Cake
        {
            Id = cakeId,
            Name = "Citronmåne",
            Price = 20.0
        };
    
        _service.CreateCake(testCake);
        var actual = _service.GetCake(cakeId);
        
        Assert.AreEqual(testCake,actual);
    }
    
    [Test]
    public void CanDeleteCake()
    {
        Guid g = new Guid("f72751a3-d450-48b2-bcf1-d081ea204a79");
        var expectedCake = _service.GetCake(g);
        
        _service.DeleteCake(g);
        Assert.That(_service.GetCakes(), Has.No.Member(expectedCake));
    }
}