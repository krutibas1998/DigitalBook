using DigitalBook.Model;

namespace DigitalBook.Services
{
    public interface IUserService
    {
        //string LogIn(List<User> users, User user); 
        string AddUser(User user);
        string ModifiedUser(int userId, User user);
        string DeletedUser(int userId );
       // string ModifiedUser(List<User> users, User user);
    }
}