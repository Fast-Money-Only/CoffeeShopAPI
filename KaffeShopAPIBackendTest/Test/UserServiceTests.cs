using _Data;
using _Data.Repository;
using Business.Service.Interfaces;
using KaffeShopAPIBackendTest.FakeRepositories;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Model;

namespace KaffeShopAPIBackendTest.Test;

[TestFixture]

public class UserServiceTests
{
    private CoffeeShopContext _coffeeShopContext;
    private FakeUserRepository _repository;
    private UserService _service;
    
    private FakeOrderRepository _orderRepo;
    private OrderService _orderService;
    
    [SetUp]
    public void Setup()
    {
        var options = DbTestOptionsClass.Create();
        _coffeeShopContext = new CoffeeShopContext(options);
        _repository = new FakeUserRepository(_coffeeShopContext);
        _service = new UserService(_repository);

        _orderRepo = new FakeOrderRepository(_coffeeShopContext);
        _orderService = new OrderService(_orderRepo);
        
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
        
        _service.CreateUser(test);
        _orderRepo.CreateOrder(newOrder);
    }

    [Test]
    public void CanGetUsers()
    {
        Guid t = new Guid("11222244-5566-7788-99AA-BBCCDDEEFF00");
        
        var newMem = new Membership
        {
            Id = Guid.NewGuid(),
            Title = "Admin"
        };
        
        var test = new User
        {
            Id = t,
            Firstname = "Magnus",
            Lastname = "Andersen",
            Email = "Madmedmig@gmail.com",
            Password = "Magnus12",
            Phone = 12121212,
            MembershipId = newMem.Id,
            Membership = newMem
        };

        _service.CreateUser(test);
        
        
        var actual = _service.GetUsers();
        Assert.That(actual.Count,Is.EqualTo(2));
        Assert.False(actual.Count == 1);
    }
    
    
    [Test]
    public void CanGetUser()
    {
        Guid g = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00");
        var newUser = _service.GetUser(g);
        Assert.AreEqual("Magnus", newUser.Firstname);
    }
    
    
    [Test]
    public void DoesUserExists()
    {
        Assert.True(_service.UserExists("Madmedmig@gmail.com"));
    }
    
    
    [Test]
    public void CanUpdateUser()
    {
        var newMem = new Membership
        {
            Id = Guid.NewGuid(),
            Title = "Admin"
        };

        Guid g = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00");
        
        var newUser = new User
        {
            Id = g,
            Firstname = "Magnus",
            Lastname = "Andersen",
            Email = "Madmedmig@gmail.com",
            Password = "Magnus1212",
            Phone = 11111111,
            MembershipId = newMem.Id,
            Membership = newMem
        };
        
        _service.UpdateUser(g, newUser);
        var updatedUser = _service.GetUser(g);

        Assert.AreEqual(11111111, updatedUser.Phone);
    }
    
    
    [Test]
    public void CanCreateUser()
    {

        var newMem = new Membership
        {
            Id = Guid.NewGuid(),
            Title = "Admin"
        };

        Guid g = new Guid("11443344-5566-7788-99AA-BBCCDDEEFF00");
        
        var expected = new User
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

        _service.CreateUser(expected);
        var actual = _service.GetUser(g);
        
        Assert.AreEqual(expected, actual);
    }
    
    
    [Test]
    public void CanDeleteUser()
    {
        Guid g = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00");
        var expected = _service.GetUser(g);
        
        _service.DeleteUser(g);
        
        Assert.That(_service.GetUsers(), Has.No.Member(expected));
    }
    
    
    [Test]
    public void CanGetUserOrders()
    {
        Guid g = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00");
        var userOrders = _service.GetUserOrders(g);
        Assert.That(userOrders.Count, Is.EqualTo(1));
    }
    
    
    [Test]
    public void CanLoginUser()
    {
        var loggedUser = _service.LoginUser("Madmedmig@gmail.com", "Magnus12");
        Assert.AreEqual("Madmedmig@gmail.com", loggedUser.Email);
    }
    
}