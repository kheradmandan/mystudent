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
    public class CI_RoleRepository : ICI_Role
    {


        private StudentDbContext db;
        public CI_RoleRepository(StudentDbContext _context)
        {
            this.db = _context;
        }


   

        public IEnumerable<CI_Role> GetAllCI_Role()
        {
            return db.CI_Roles.ToList();
        }

        public CI_Role GetCI_RoleById(int cI_RoleId)
        {
            return db.CI_Roles.Find(cI_RoleId);
        }

        public bool InsertCI_Role(CI_Role cI_Role)
        {
            try
            {
                db.CI_Roles.Add(cI_Role);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    

        public bool UpdateCI_Role(CI_Role cI_Role)
        {
            try
            {
                db.Entry(cI_Role).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool DeleteCI_Role(CI_Role cI_Role)
        {
            try
            {
                db.Entry(cI_Role).State = EntityState.Deleted;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCI_Role(int cI_Role)
        {
            try
            {
                var SelectCi_Role = GetCI_RoleById(cI_Role);
                db.Entry(SelectCi_Role).State = EntityState.Deleted;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
