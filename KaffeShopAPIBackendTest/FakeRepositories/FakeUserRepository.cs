using _Data;
using _Data.Repository;
using Model;

namespace KaffeShopAPIBackendTest.FakeRepositories;

public class FakeUserRepository : IUserRepository
{
    private readonly CoffeeShopContext _context;

    public FakeUserRepository(CoffeeShopContext context)
    {
        _context = context;
    }
    
    public IList<User> GetUsers()
    {
        return _context.Users.ToList();
    }

    public User GetUser(Guid id)
    {
        return _context.Users.Where(x =>x.Id == id).FirstOrDefault() ?? new User();
    }

    public bool UserExists(string email, string password)
    {
        return _context.Users.Any(x => x.Email == email && x.Password == password);
    }

    public User UpdateUser(Guid id, User user)
    {
        var userToUpdate = GetUser(id);
        userToUpdate.Firstname = user.Firstname;
        userToUpdate.Lastname = user.Lastname;
        userToUpdate.Email = user.Email;
        userToUpdate.Phone = user.Phone;
        _context.SaveChanges();
        return userToUpdate;
    }

    public User CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public void DeleteUser(Guid id)
    {
        _context.Users.Remove(GetUser(id));
        _context.SaveChanges();
    }

    public IList<Order> GetUserOrders(Guid id)
    {
        IList<Order> orders = _context.Orders.ToList();
        IList<Order> userOrders = new List<Order>();
        foreach (Order o in orders)
        {
            if (o.UserId == id)
            { 
                userOrders.Add(o);
            }
        }
        return userOrders;
    }

    public User LoginUser(string email, string password)
    {
        return _context.Users.FirstOrDefault(_user => _user.Email == email && _user.Password == password);
    }
}