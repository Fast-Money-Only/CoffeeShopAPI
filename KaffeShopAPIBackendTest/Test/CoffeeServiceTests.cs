using _Data;
using _Data.Repository;
using KaffeShopAPIBackendTest.FakeRepositories;
using Model;

namespace KaffeShopAPIBackendTest.Test;

[TestFixture]

public class CoffeeServiceTests
{
    private CoffeeShopContext _coffeeShopContext;
    private FakeCoffeeRepository _repository;
    private CoffeeService _service;

    private FakeCakeRepository _cakeRepo;
    private CakeService _cakeService;

    private FakeIngredientRepository _ingredientRepository;
    private IngredientService _ingredientService;

    [SetUp]
    public void SetUp()
    {
        var options = DbTestOptionsClass.Create();
        _coffeeShopContext = new CoffeeShopContext(options);
        _repository = new FakeCoffeeRepository(_coffeeShopContext);
        _service = new CoffeeService(_repository);

        _cakeRepo = new FakeCakeRepository(_coffeeShopContext);
        _cakeService = new CakeService(_cakeRepo);

        _ingredientRepository = new FakeIngredientRepository(_coffeeShopContext);
        _ingredientService = new IngredientService(_ingredientRepository);

        Guid testCID = new Guid("b30fd476-77e2-4196-ac21-6a69f3a7e425");

        var testCoffee = new Coffee
        {
            Id = testCID,
            Name = "Espresso",
            Price = 40.0
        };

        Guid testcakeID = new Guid("f91afa18-8233-49b5-981a-452f17e698d3");

        var testCake = new Cake
        {
            Id = testcakeID,
            Name = "Drømmekage",
            Price = 25.5
        };

        Guid ingId = new Guid("728889cd-35dc-4601-816e-5b1e192f091a");

        var testIng = new Ingredient
        {
            Id = ingId,
            Name = "Cream",
        };

        Guid testCoffIng = new Guid("87049c5d-a440-46d1-a476-b2f55e6e0d4c");
        var testCofIng = new CoffeeIngredient
        {
            Id = testCoffIng,
            IngredientId = ingId,
            Ingredient = testIng,
            CoffeeId = testCID,
            Coffee = testCoffee
        };

        Guid coffCake = new Guid("bfe4d3f3-ef1a-41c0-81dd-b45094467556");
        var testCoffeeCake = new CoffeeCake
        {
            Id = coffCake,
            CakeId = testcakeID,
            Cake = testCake,
            CoffeeId = testCID,
            Coffee = testCoffee
        };

        _service.CreateCoffee(testCoffee);
        _cakeService.CreateCake(testCake);
        _ingredientService.CreateIngredient(testIng);
        _service.CreateCoffeeIngredient(testCofIng);
        _service.CreateCoffeeCake(testCoffeeCake);
    }

    [Test]
    public void CanGetAllCoffees()
    {
        var actual = _service.GetCoffees();
        Assert.That(actual.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void CanCreateCoffee()
    {
        Guid coffeeId = new Guid("d328c161-3491-4729-83a5-bd462718a6b1");
        
        var testCoffee = new Coffee
        {
            Id = coffeeId,
            Name = "Pernicano",
            Price = 35.0
        };

        _service.CreateCoffee(testCoffee);
        var actual = _service.GetCoffees();
        
        Assert.That(actual.Count, Is.EqualTo(2));
    }
    
    [Test]
    public void CanDeleteCoffee()
    {
        Guid testCID = new Guid("b30fd476-77e2-4196-ac21-6a69f3a7e425");
        var expectedCoffee = _service.GetCoffee(testCID);
        
        _service.DeleteCoffee(testCID);
        Assert.That(_service.GetCoffees(), Has.No.Member(expectedCoffee));
    }
    
    [Test]
    public void CanSeeCoffeesIngredients()
    {
        Guid testCID = new Guid("b30fd476-77e2-4196-ac21-6a69f3a7e425");
        var actual = _service.CoffeeIngredients(testCID);
        
        Assert.That(actual.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void CanGetCoffeeCakes()
    {
        Guid testCID = new Guid("b30fd476-77e2-4196-ac21-6a69f3a7e425");
        var actual = _service.CoffeeCake(testCID);
        
        Assert.That(actual.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void CanGetSpecificCoffee()
    {
        Guid coffId = new Guid("3909e8d0-b8ae-43a2-b981-6c918c485ce6");

        var testCoffee = new Coffee
        {
            Id = coffId,
            Name = "Magnucano",
            Price = 100.0
        };
        _service.CreateCoffee(testCoffee);

        var actual = _service.GetCoffee(coffId);
        
        Guid existingCoffee = new Guid("b30fd476-77e2-4196-ac21-6a69f3a7e425");
        var actual2 = _service.GetCoffee(existingCoffee);
        
        
        Assert.AreEqual(testCoffee,actual);
        Assert.AreEqual("Espresso", actual2.Name);
    }
    
    [Test]
    public void CanCreateCoffeeIngredient()
    {
        Guid ingId = new Guid("9e4f72ca-148d-496b-ad6e-5e60412dafb6");
        Guid coffeeIngr = new Guid("8a90b88d-3639-4092-a28f-84465a649608");
        Guid existingCoffee = new Guid("b30fd476-77e2-4196-ac21-6a69f3a7e425");
        
        var ingredient = new Ingredient
        {
            Id = ingId,
            Name = "Beans"
        };

        _ingredientService.CreateIngredient(ingredient);

        var coffee = _service.GetCoffee(existingCoffee);

        var newCoffeeIngredient = new CoffeeIngredient
        {
            Id = coffeeIngr,
            IngredientId = ingId,
            Ingredient = ingredient,
            CoffeeId = existingCoffee,
            Coffee = coffee
        };

        _service.CreateCoffeeIngredient(newCoffeeIngredient);

        var actual = _service.CoffeeIngredients(existingCoffee);
        Assert.That(actual.Count, Is.EqualTo(2));
    }
    
    [Test]
    public void CanCreateCoffeeCake()
    {
        Guid existingCoffee = new Guid("b30fd476-77e2-4196-ac21-6a69f3a7e425");
        Guid cakeId = new Guid("8369cb14-f14c-49b8-b633-5a99ac5c1084");
        Guid cofCake = new Guid("97c42c06-be0f-4e06-b0e1-9600b51c89d1");

        var testCake = new Cake
        {
            Id = cakeId,
            Name = "Brunsviger",
            Price = 20.5
        };

        _cakeService.CreateCake(testCake);
        var coffee = _service.GetCoffee(existingCoffee);

        var coffeeCake = new CoffeeCake
        {
            Id = cofCake,
            CakeId = cakeId,
            Cake = testCake,
            CoffeeId = existingCoffee,
            Coffee = coffee
        };

        _service.CreateCoffeeCake(coffeeCake);
        var actual = _service.CoffeeCake(existingCoffee);
        Assert.That(actual.Count, Is.EqualTo(2));
    }
}