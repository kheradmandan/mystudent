using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.Repositories
{
    public interface IUser
    {


     
        User GetUserById(int userId);
   
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool DeleteUser(int userId);
      


        public IEnumerable<User> GetAllUsers();
        bool IsExistUser(User user);    
        public void AddUser(User user);
        User GetUserForLogin(string Email);
        public void save();

    }
}
