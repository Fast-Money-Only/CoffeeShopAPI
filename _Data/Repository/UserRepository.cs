using Model;

namespace _Data.Repository;

public class UserRepository : IUserRepository
{
    public IList<User> GetUsers()
    {
        throw new NotImplementedException();
    }

    public User GetUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool UserExists(string email, string password)
    {
        throw new NotImplementedException();
    }

    public User UpdateUser(Guid id, User user)
    {
        throw new NotImplementedException();
    }

    public User CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public IList<Order> GetUserOrders(Guid id)
    {
        throw new NotImplementedException();
    }
}