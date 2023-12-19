using _Data;
using _Data.Repository;
using Business.Service;
using KaffeShopAPIBackendTest.FakeRepositories;
using Model;

namespace KaffeShopAPIBackendTest.Test;

[TestFixture]

public class CoffeePlaceServiceTests
{
    private CoffeeShopContext _coffeeShopContext;
    private FakeCoffeePlaceRepository _repository;
    private CoffeePlaceService _service;

    private FakeAddressRepository _addressRepository;
    private AddressService _addressService;
    
    
    
    // Note: Vi kører ikke tests i denne her klasse, da vi ikke har en createCoffeePlace funktion, hvilket er nødvendigt for at kunne lave et object.
    // Hvis vi havde en createCoffeePlace funktion, kunne testene have set ud som de gør i test metoderne.
    
    
    

    [SetUp]
    public void SetUp()
    {
        var options = DbTestOptionsClass.Create();
        _coffeeShopContext = new CoffeeShopContext(options);
        _repository = new FakeCoffeePlaceRepository(_coffeeShopContext);
        _service = new CoffeePlaceService(_repository);

        _addressRepository = new FakeAddressRepository(_coffeeShopContext);
        _addressService = new AddressService(_addressRepository);

        Guid addressId = new Guid("7203e944-f268-4532-ad6b-47d1bb209581");

        var addr = new Address
        {
            AddressID = addressId,
            CityName = "Tønder",
            HouseNumber = "2b",
            StreetName = "Popsensgade",
            PostNumber = 6270
        };

        _addressService.CreateAddress(addr);

        Guid coffeePlaceId = new Guid("e389f4ec-53f7-4d32-ae07-93b19f3594ba");
        var coffeePlace = new CoffeePlace
        {
            CoffeePlaceId = coffeePlaceId,
            CoffeePlaceName = "Mega coffee",
            AddressId = addressId,
            Address = addr
        };
        
    }

    [Test]
    public void CanGetCoffeePlace()
    {
        Guid coffeePlaceId = new Guid("e389f4ec-53f7-4d32-ae07-93b19f3594ba");
        Guid addressId = new Guid("7203e944-f268-4532-ad6b-47d1bb209581");

        var addr = _addressService.GetAddress(addressId);
        
        CoffeePlace newCoffeePlace = new CoffeePlace
        {
            CoffeePlaceId = coffeePlaceId,
            CoffeePlaceName = "Mega coffee",
            AddressId = addressId,
            Address = addr
        };
        
        
        var actual = _service.GetCoffeePlace(coffeePlaceId);
        
        Assert.AreEqual("Mega coffee",actual.CoffeePlaceName);
    }
    
    [Test]
    public void CanGetAllCoffeePlaces()
    {
        var actual = _service.GetCoffeePlaces();
        
        Assert.That(actual.Count, Is.EqualTo(3));
    }
}