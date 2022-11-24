using Test.Models;

namespace Test.Services
{
    public interface IUserServices
    {
        void AddUser(User user);
        User GetUser(int id);
        void UpdateUser(User user, int id);
        void DeleteUser(int id);
    }
}
