using Business.Service.Interfaces;
using Model;

namespace _Data.Repository;

public class UserService : IUserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IList<User> GetUsers()
    {
        return _userRepository.GetUsers();
    }

    public User GetUser(Guid id)
    {
        return _userRepository.GetUser(id);
    }

    public bool UserExists(string email, string password)
    {
        return _userRepository.UserExists(email, password);
    }

    public User UpdateUser(Guid id, User user)
    {
        return _userRepository.UpdateUser(id, user);
    }

    public User CreateUser(User user)
    {
        return _userRepository.CreateUser(user);
    }

    public void DeleteUser(Guid id)
    {
        _userRepository.DeleteUser(id);
    }

    public IList<Order> GetUserOrders(Guid id)
    {
        return _userRepository.GetUserOrders(id);
    }
}