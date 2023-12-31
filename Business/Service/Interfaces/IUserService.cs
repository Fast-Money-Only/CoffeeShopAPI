using Model;
namespace Business.Service.Interfaces;

public interface IUserService
{
    IList<User> GetUsers();
    User? GetUser(Guid id);
    bool UserExists(string email); //Bruges til login
    User UpdateUser(Guid id, User user);
    User CreateUser(User user);
    void DeleteUser(Guid id);
    IList<Order> GetUserOrders(Guid id);
    User LoginUser(string email, string password);

}