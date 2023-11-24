using Model;
namespace _Data.Repository;

public interface IUserRepository
{
    IList<User> GetUsers();
    User GetUser(Guid id);
    bool UserExists(string email, string password); //Bruges til login
    User UpdateUser(Guid id, User user);
    User CreateUser(User user);
    

}