using _Data;
using _Data.Repository;
using KaffeShopAPIBackendTest.FakeRepositories;
using Model;

namespace KaffeShopAPIBackendTest.Test;

[TestFixture]

public class IngredientServiceTests
{
    private CoffeeShopContext _coffeeShopContext;
    private FakeIngredientRepository _repository;
    private IngredientService _service;


    [SetUp]
    public void SetUp()
    {
        var options = DbTestOptionsClass.Create();
        _coffeeShopContext = new CoffeeShopContext(options);
        _repository = new FakeIngredientRepository(_coffeeShopContext);
        _service = new IngredientService(_repository);

        Guid g = new Guid("775bc37b-b4a5-4509-9787-b9f693fc87d6");

        var testIngredient = new Ingredient
        {
            Id = g,
            Name = "Coffee Bean"
        };
        _service.CreateIngredient(testIngredient);
    }

    [Test]
    public void CanCreateIngredient()
    {
        
        Guid g = new Guid("5adfed77-ef39-4f1b-8c37-e19b14aa4b14");

        var testIngredient = new Ingredient
        {
            Id = g,
            Name = "Milk"
        };
        _service.CreateIngredient(testIngredient);
        var actual = _service.GetIngredient(g);
        Assert.AreEqual(testIngredient,actual);
    }
    
    [Test]
    public void CanGetIngredients()
    {
        var actual = _service.GetIngredients();
        Assert.That(actual.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void CanGetSpecificIngredient()
    {
        Guid g = new Guid("775bc37b-b4a5-4509-9787-b9f693fc87d6");

        var actual = _service.GetIngredient(g);
        Assert.AreEqual("Coffee Bean", actual.Name);
    }
    
    [Test]
    public void CanDeleteIngredient()
    {
        Guid g = new Guid("775bc37b-b4a5-4509-9787-b9f693fc87d6");
        var actual = _service.GetIngredient(g);
        
        _service.DeleteIngredient(g);
        Assert.That(_service.GetIngredients(),Has.No.Member(actual));
    }
}