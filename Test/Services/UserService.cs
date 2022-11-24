using AutoMapper;
using Test.Data;
using Test.Models;
namespace Test.Services
{
    public class UserService : IUserServices
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        //private static List<User> UserList = new List<User>();

        //POST
        public void AddUser(User user)
        {
            var dbUser = _context.Users;
            //user.UserId = dbUser.Count + 1;
            dbUser.Add(user);
            _context.SaveChanges();
        }

        //GET
        public User GetUser(int id)
        {
            var dbUser = _context.Users.ToList();
            User emptyUser = new User();
            foreach(User user in dbUser){
                if(user.UserId == id){
                    return user;
                }
            }
            return emptyUser;

        }
       
        //PUT
        public void UpdateUser(User userToUpdate, int id)
        {
            var dbUser = _context.Users;

            foreach(User user in dbUser)
            {
                if(user.UserId == id)
                {

                    user.UserId = userToUpdate.UserId;
                    user.Name = userToUpdate.Name;
                    user.email = userToUpdate.email;
                    user.phone = userToUpdate.phone;
                    _context.SaveChanges();
                }
            }


        }

        //Delete
        public void DeleteUser(int id)
        {
            var dbUser = _context.Users;
            foreach (User user in dbUser)
            {
                if (user.UserId == id)
                {
                    dbUser.Remove(user);
                    _context.SaveChanges();
                }
            }
            
        }
    }
}




