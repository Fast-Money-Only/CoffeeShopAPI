using _Data;
using _Data.Repository;
using KaffeShopAPIBackendTest.FakeRepositories;
using Model;

namespace KaffeShopAPIBackendTest.Test;

[TestFixture]

public class OrderServiceTests
{
    
    private CoffeeShopContext _coffeeShopContext;
    private FakeOrderRepository _repository;
    private OrderService _service;

    [SetUp]
    public void SetUp()
    {
        var options = DbTestOptionsClass.Create();
        _coffeeShopContext = new CoffeeShopContext(options);
        _repository = new FakeOrderRepository(_coffeeShopContext);
        _service = new OrderService(_repository);    
        
        var newMem = new Membership
        {
            Id = Guid.NewGuid(),
            Title = "Admin"
        };

        Guid g = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00");
        
        var test = new User
        {
            Id = g,
            Firstname = "Magnus",
            Lastname = "Andersen",
            Email = "Madmedmig@gmail.com",
            Password = "Magnus12",
            Phone = 12121212,
            MembershipId = newMem.Id,
            Membership = newMem
        };

        Guid oID = new Guid("820b61be-fa03-45ce-9c17-8bfa654706e2");
        Guid cfPlace = new Guid("0e63b1a8-244e-467f-8596-1c1c9997f148");
        Guid addressID = new Guid("d52bee8e-0e38-447a-b066-6c427fb8d00d");

        var address = new Address
        {
            AddressID = addressID,
            CityName = "Tønder",
            HouseNumber = "5b",
            PostNumber = 6270,
            StreetName = "Astro Boy Hansen"
        };
        
        var newCoffeePlace = new CoffeePlace
        {
            CoffeePlaceId = cfPlace,
            Address = address,
            AddressId = addressID,
            CoffeePlaceName = "Big juicy boy"
        };

        var newOrder = new Order
        {
            Id = oID,
            Created = "Now",
            Pickup = "Now",
            IsDone = false,
            CoffeePlaceId = cfPlace,
            CoffeePlace = newCoffeePlace,
            UserId = g,
            User = test
        };

        _service.CreateOrder(newOrder);
    }

    [Test]
    public void CanGetAllOrders()
    {
        var actual = _service.GetAllOrders();
        Assert.That(actual.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void IsOrderDone()
    {
        Guid oID = new Guid("820b61be-fa03-45ce-9c17-8bfa654706e2");
        var actual = _service.GetOrder(oID);
        
        Assert.False(actual.IsDone);
    }
    
    [Test]
    public void CanCreateOrder()
    {
        var newMem = new Membership
        {
            Id = Guid.NewGuid(),
            Title = "Admin"
        };

        Guid g = new Guid("11223344-6666-7788-99AA-BBCCDDEEFF00");
        
        var test = new User
        {
            Id = g,
            Firstname = "Magnus",
            Lastname = "Andersen",
            Email = "Madmedmig@gmail.com",
            Password = "Magnus12",
            Phone = 12121212,
            MembershipId = newMem.Id,
            Membership = newMem
        };

        Guid oID = new Guid("b8045ef6-65c7-4e3c-8875-081c1a52171a");
        Guid cfPlace = new Guid("5897caf9-c4f9-4634-ac0c-99016e4214f2");
        Guid addressID = new Guid("dd0f57c0-3526-460c-ab07-44efd2ac2152");

        var address = new Address
        {
            AddressID = addressID,
            CityName = "Tønder",
            HouseNumber = "5b",
            PostNumber = 6270,
            StreetName = "Astro Boy Hansen"
        };
        
        var newCoffeePlace = new CoffeePlace
        {
            CoffeePlaceId = cfPlace,
            Address = address,
            AddressId = addressID,
            CoffeePlaceName = "Big juicy boy"
        };

        var newOrder = new Order
        {
            Id = oID,
            Created = "Now",
            Pickup = "Now",
            IsDone = false,
            CoffeePlaceId = cfPlace,
            CoffeePlace = newCoffeePlace,
            UserId = g,
            User = test
        };

        _service.CreateOrder(newOrder);

        var expected = _service.GetOrder(oID);
        Assert.AreEqual(newOrder,expected);
    }
    
    [Test]
    public void CanGetUserOrders()
    {
        Guid g = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00");
        var listOfUserOrders = _service.GetUserOrders(g);
        
        Assert.That(listOfUserOrders.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void CanCreateOrderProduct()
    {
        Guid prodID = new Guid("55871a18-3355-4f3d-a6b5-59122e3585f2");
        Guid prodNum = new Guid("78941861-a0c9-4b22-8190-e5e374c9ce6f");
        Guid orderProdID = new Guid("c4ab285a-c7f0-4c30-b500-c4dcedf1bd96");
        Guid orderID = new Guid("820b61be-fa03-45ce-9c17-8bfa654706e2");

        var order = _service.GetOrder(orderID);
        
        var newProd = new Product
        {
            ProductId = prodID,
            ProductName = "Whipped Cream",
            ProductNumber = prodNum
        };

        var prodOrder = new OrderProduct
        {
            Id = orderProdID,
            ProductId = prodID,
            Product = newProd,
            OrderId = orderID,
            Order = order,
            Quantity = 1
        };

        _service.CreateOrderProduct(prodOrder);
        
        var actual = _service.GetOrderProducts(orderID);
        Assert.That(actual.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void CanGetOrderProducts()
    {
        Guid orderID = new Guid("820b61be-fa03-45ce-9c17-8bfa654706e2");
        var orderProds = _service.GetOrderProducts(orderID);
        Assert.That(orderProds.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void CanGetOrder()
    {
        Guid orderID = new Guid("820b61be-fa03-45ce-9c17-8bfa654706e2");
        var order = _service.GetOrder(orderID);
        Assert.AreEqual("Big juicy boy",order.CoffeePlace.CoffeePlaceName);
    }
    
    [Test]
    public void CanGetPendingOrders()
    {
        var actual = _service.GetPending();
        Assert.That(actual.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void CanGetDoneOrders()
    {
        var actual = _service.GetDone();
        Assert.That(actual.Count, Is.EqualTo(0));
    }
}