using _Data;
using _Data.Repository;
using Business.Service;
using KaffeShopAPIBackendTest.FakeRepositories;
using Model;

namespace KaffeShopAPIBackendTest.Test;

[TestFixture]

public class AddressServiceTests
{
    private CoffeeShopContext _coffeeShopContext;
    private FakeAddressRepository _repository;
    private AddressService _service;




    [SetUp]
    public void SetUp()
    {
        var options = DbTestOptionsClass.Create();
        _coffeeShopContext = new CoffeeShopContext(options);
        _repository = new FakeAddressRepository(_coffeeShopContext);
        _service = new AddressService(_repository);

        Guid addId = new Guid("73e067c1-dc78-498a-81e7-abea66590427");

        var testAddress = new Address
        {
            AddressID = addId,
            CityName = "Tønder",
            HouseNumber = "2b",
            StreetName = "Popsensgade",
            PostNumber = 1212
        };

        _service.CreateAddress(testAddress);
    }

    [Test]
    public void CanCreateAddress()
    {
        Guid newAdd = new Guid("b1561c40-9a86-48bf-9a0c-a20de79065ba");

        var newAddress = new Address
        {
            AddressID = newAdd,
            CityName = "Aabenraa",
            HouseNumber = "10",
            StreetName = "Elmegårdsvej",
            PostNumber = 6270
        };

        _service.CreateAddress(newAddress);

        var actual = _service.GetAddress(newAdd);
        Assert.AreEqual(newAddress,actual);
    }
    
    [Test]
    public void CanFindAddress()
    {
        Guid addId = new Guid("73e067c1-dc78-498a-81e7-abea66590427");

        var address = _service.GetAddress(addId);
        Assert.AreEqual("Tønder", address.CityName);
    }
    
    
    [Test]
    public void CanUpdateAddress()
    {
        Guid addId = new Guid("73e067c1-dc78-498a-81e7-abea66590427");

        var newAddress = new Address
        {
            AddressID = addId,
            CityName = "Møgeltønder",
            HouseNumber = "2b",
            StreetName = "Popsensgade",
            PostNumber = 1212
        };

        _service.UpdateAddress(addId, newAddress);
        var updatedAddress = _service.GetAddress(addId);
        Assert.AreEqual("Møgeltønder",updatedAddress.CityName);
    }
    
    [Test]
    public void CanDeleteAddress()
    {
        Guid addId = new Guid("73e067c1-dc78-498a-81e7-abea66590427");
        var address = _service.GetAddress(addId);
        
        _service.DeleteAddress(addId);
        Assert.That(_service.GetAddress(addId),Is.Null);
    }
}