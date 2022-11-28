using Test.Models;

namespace Test.Services
{
    public interface IUserServices
    {
        void AddUser(User user);
        List<User> GetUser();
        void UpdateUser(User user, int id);
        void DeleteUser(int id);
    }
}
