using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;

namespace _Data.Repository;

public class UserRepository : IUserRepository
{
    private readonly CoffeeShopContext _context;

    public UserRepository(CoffeeShopContext context)
    {
        _context = context;

    }

    public IList<User> GetUsers()
    {
        return _context
            .Users
            .ToList();
    }

    public User GetUser(Guid id)
    {
        return _context.Users.Find(id);
    }

    public bool UserExists(string email)
    {
        return _context.Users.Any(x => x.Email == email);
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
        IList<Order> userOrders = null;
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