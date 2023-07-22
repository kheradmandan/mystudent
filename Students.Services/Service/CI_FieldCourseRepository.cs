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
    public class CI_FieldCourseRepository : ICI_FieldCourse
    {

        private StudentDbContext db;
        public CI_FieldCourseRepository(StudentDbContext _context)
        {
            this.db = _context;
        }
  

        public IEnumerable<CI_FieldCourse> GetAllCI_FieldCourses()
        {
            return db.CI_FieldCourses.ToList();
        }

        public CI_FieldCourse GetCI_FieldCourseById(int cI_FieldCourseId)
        {
            return db.CI_FieldCourses.Find(cI_FieldCourseId); 
        }

        public bool InsertCI_FieldCourse(CI_FieldCourse cI_FieldCourse)
        {
            try
            {
                db.CI_FieldCourses.Add(cI_FieldCourse);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdateCI_FieldCourse(CI_FieldCourse cI_FieldCourse)
        {
            try
            {
                db.Entry(cI_FieldCourse).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCI_FieldCourse(CI_FieldCourse cI_FieldCourse)
        {
            try
            {
                db.Entry(cI_FieldCourse).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCI_FieldCourse(int cI_FieldCourse)
        {
            try
            {
                var cIFieldCourse = GetCI_FieldCourseById(cI_FieldCourse);
                DeleteCI_FieldCourse(cIFieldCourse);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
        public void Save()
        {
            db.SaveChanges();
        }


    }
}
