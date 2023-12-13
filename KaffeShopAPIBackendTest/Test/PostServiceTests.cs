using _Data;
using _Data.Repository;
using KaffeShopAPIBackendTest.FakeRepositories;
using Model;

namespace KaffeShopAPIBackendTest.Test;

[TestFixture]

public class PostServiceTests
{
    private CoffeeShopContext _coffeeShopContext;
    private FakePostRepository _repository;
    private PostService _service;
    private UserService _userService;
    private FakeUserRepository _userRepo;

    [SetUp]
    public void SetUp()
    {
        var options = DbTestOptionsClass.Create();
        _coffeeShopContext = new CoffeeShopContext(options);
        _repository = new FakePostRepository(_coffeeShopContext);
        _service = new PostService(_repository);

        _userRepo = new FakeUserRepository(_coffeeShopContext);
        _userService = new UserService(_userRepo);

        Guid userID = new Guid("312ba721-7720-4681-a5ca-6a8f67d818f7");
        Guid postID = new Guid("b0c79e8f-9e5d-400a-abe3-656eeeba2eb7");
        Guid membershipID = new Guid("d4295048-b175-4d16-aed0-ee0a6a4624f9");

        var testMembership = new Membership
        {
            Id = membershipID,
            Title = "Customer"
        };
        
        var testUser = new User
        {
            Id = userID,
            Firstname = "Magnus",
            Lastname = "Andersen",
            Email = "Madmedmig@gmail.com",
            Password = "Magnus12",
            Phone = 12121212,
            MembershipId = testMembership.Id,
            Membership = testMembership
        };

        var testPost = new Post
        {
            Id = postID,
            Title = "Mega nice coffee",
            Img = "blabla.jpg",
            UserId = userID,
            User = testUser
        };
        
        _service.AddPost(testPost);
    }

    [Test]
    public void CanGetAllPosts()
    {
        var actual = _service.GetPosts();
        Assert.That(actual.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void CanGetSpecificPost()
    {
        Guid postID = new Guid("b0c79e8f-9e5d-400a-abe3-656eeeba2eb7");
        var post = _service.GetPost(postID);
        Assert.AreEqual("blabla.jpg", post.Img);
    }
    
    [Test]
    public void CanAddPost()
    {
        Guid userID = new Guid("421f7a5d-3524-4864-b17a-71bf20b387a2");
        Guid postID = new Guid("49d81bef-7282-493e-9f05-d68d55f1a2d7");
        Guid membershipID = new Guid("c784644b-31a1-4d6e-a958-41a0e6cf1de0");

        var testMembership = new Membership
        {
            Id = membershipID,
            Title = "Customer"
        };
        
        var testUser = new User
        {
            Id = userID,
            Firstname = "Magnus",
            Lastname = "Andersen",
            Email = "Madmedmig@gmail.com",
            Password = "Magnus12",
            Phone = 12121212,
            MembershipId = testMembership.Id,
            Membership = testMembership
        };

        var addedPost = new Post
        {
            Id = postID,
            Title = "Mega nice coffee",
            Img = "blabla.jpg",
            UserId = userID,
            User = testUser
        };

        _service.AddPost(addedPost);
        var actual = _service.GetPost(postID);
        Assert.AreEqual(addedPost,actual);
    }
    
    [Test]
    public void CanDeletePost()
    {
        Guid postID = new Guid("b0c79e8f-9e5d-400a-abe3-656eeeba2eb7");
        var expected = _service.GetPost(postID);
        
        _service.DeletePost(postID);
        
        Assert.That(_service.GetPosts(), Has.No.Member(expected));
    }
    
}