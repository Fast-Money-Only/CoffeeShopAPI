using _Data;
using _Data.Repository;
using ClassLibrary1.Service.Classes;
using KaffeShopAPIBackendTest.FakeRepositories;
using Model;

namespace KaffeShopAPIBackendTest.Test;

[TestFixture]

public class CustomCoffeeServiceTests
{
    private CoffeeShopContext _coffeeShopContext;
    private FakeCustomCoffeeRepository _repository;
    private CustomCoffeeService _service;

    private FakeIngredientRepository _ingredientRepository;
    private IngredientService _ingredientService;

    [SetUp]
    public void SetUp()
    {
        var options = DbTestOptionsClass.Create();
        _coffeeShopContext = new CoffeeShopContext(options);
        _repository = new FakeCustomCoffeeRepository(_coffeeShopContext);
        _service = new CustomCoffeeService(_repository);

        _ingredientRepository = new FakeIngredientRepository(_coffeeShopContext);
        _ingredientService = new IngredientService(_ingredientRepository);

        Guid g = new Guid("a29422ee-01cb-469b-8ac0-215455e5384d");
        
        var testCustomCoffee = new CustomCoffee
        {
            CustomCoffeeId = g,
            Name = "Pernicano",
            Price = 250.0
        };
        
        _service.CreateCustomCoffee(testCustomCoffee);
        
        Guid ingId = new Guid("775bc37b-b4a5-4509-9787-b9f693fc87d6");

        var testIngredient = new Ingredient
        {
            Id = ingId,
            Name = "Coffee Bean"
        };

        _ingredientService.CreateIngredient(testIngredient);

        Guid ingCof = new Guid("6f2fab3a-56e9-4c9c-939c-ece9f5ff3a9d");

        var customCofIng = new CCoffeIngredient
        {
            Id = ingCof,
            IngredientId = ingId,
            Ingredient = testIngredient,
            CustomCoffeeId = g,
            CustomCoffee = testCustomCoffee
        };

        _service.CreateCustomCoffeeIngredient(customCofIng);
    }

    [Test]
    public void CanCreateCustomCoffee()
    {
        Guid g = new Guid("1ca58dc9-1914-4726-9ff6-f9c5d054103d");
        
        var testCustomCoffee = new CustomCoffee
        {
            CustomCoffeeId = g,
            Name = "Americano"
        };

        _service.CreateCustomCoffee(testCustomCoffee);
        var actual = _service.GetCustomCoffee(g);
        
        Assert.AreEqual(testCustomCoffee,actual);
    }
    
    [Test]
    public void CanGetCustomCoffee()
    {
        Guid g = new Guid("a29422ee-01cb-469b-8ac0-215455e5384d");

        var actual = _service.GetCustomCoffee(g);
        Assert.AreEqual("Pernicano",actual.Name);
    }
    
    [Test]
    public void CanCreateCustomCoffeeIngredient()
    {
        Guid ingId = new Guid("0738ec8b-4d5b-4414-823e-748cfdb594a6");
        Guid customCID = new Guid("a29422ee-01cb-469b-8ac0-215455e5384d");
        Guid customCofIngId = new Guid("bca53ba9-89e2-49fe-850e-b7be1efb511a");
        
        var testIngredient = new Ingredient
        {
            Id = ingId,
            Name = "Milk"
        };

        _ingredientService.CreateIngredient(testIngredient);

        var customCof = _service.GetCustomCoffee(customCID);

        var newCIng = new CCoffeIngredient
        {
            Id = customCofIngId,
            IngredientId = ingId,
            Ingredient = testIngredient,
            CustomCoffeeId = customCID,
            CustomCoffee = customCof
        };

        _service.CreateCustomCoffeeIngredient(newCIng);

        var actual = _service.CustomCoffeeIngredients(customCID);

        Assert.That(actual.Count, Is.EqualTo(2));
    }
    
    [Test]
    public void CanGetCustomCoffeeIngredients()
    { 
        Guid g = new Guid("a29422ee-01cb-469b-8ac0-215455e5384d");
        var actual = _service.CustomCoffeeIngredients(g);
        
        Assert.That(actual.Count, Is.EqualTo(1));
    }
}