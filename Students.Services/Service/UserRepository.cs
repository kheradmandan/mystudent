using Microsoft.EntityFrameworkCore;
using Students.Domain.Entities;
using Students.Persistence.DbContexts;
using Students.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.Service
{
    public class UserRepository : IUser
    {
        private StudentDbContext db;
        public UserRepository(StudentDbContext _context)
        {
            this.db = _context;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return db.Users.ToList();
        }
        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public User? GetUserForLogin(string UserName)
        {
            return db.Users.FirstOrDefault(x => x.UserName.ToLower() == UserName.ToLower());
        }

        public bool IsExistUser(User user)
        {
            return db.Users.Any(x => x.UserName == user.UserName );
        }
        public void save()
        {
            db.SaveChanges();
        }

        public User GetUserById(int userId)
        {
            return db.Users.Find(userId);
        }

        public bool UpdateUser(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var user = GetUserById(userId);
                db.Entry(user).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
