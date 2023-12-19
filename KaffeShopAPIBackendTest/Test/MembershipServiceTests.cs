using _Data;
using _Data.Repository;
using KaffeShopAPIBackendTest.FakeRepositories;
using Model;

namespace KaffeShopAPIBackendTest.Test;

[TestFixture]

public class MembershipServiceTests
{
    private CoffeeShopContext _coffeeShopContext;
    private FakeMembershipRepository _repository;
    private MembershipService _service;

    [SetUp]
    public void SetUp()
    {
        var options = DbTestOptionsClass.Create();
        _coffeeShopContext = new CoffeeShopContext(options);
        _repository = new FakeMembershipRepository(_coffeeShopContext);
        _service = new MembershipService(_repository);

        Guid g = new Guid("65a56811-eb22-467d-8659-bd3c8a7bd8f2");

        var testMem = new Membership
        {
            Id = g,
            Title = "Customer"
        };

        _service.CreateMembership(testMem);

    }

    [Test]
    public void CanCreateMembership()
    {
        Guid g = new Guid("74d3b354-5237-48ae-8a64-1afcb6fc7503");

        var mem = new Membership
        {
            Id = g,
            Title = "Admin"
        };

        _service.CreateMembership(mem);
        var expected = _service.GetMemberhip(g);
        Assert.AreEqual(mem,expected);
    }
    
    [Test]
    public void CanGetMembership()
    {
        Guid g = new Guid("65a56811-eb22-467d-8659-bd3c8a7bd8f2");
        var membership = _service.GetMemberhip(g);
        Assert.AreEqual("Customer",membership.Title);
    }
}