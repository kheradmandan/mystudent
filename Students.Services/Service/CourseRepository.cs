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
   public class CourseRepository : ICourse
    {
        private StudentDbContext db;
        public CourseRepository(StudentDbContext _context)
        {
            this.db = _context;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return db.Courses.ToList(); ;
        }

        public Course GetCourseById(int courseId)
        {
            return db.Courses.Find(courseId);
        }

        public bool InsertCourse(Course course)
        {
            try
            {
                db.Courses.Add(course);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdateCourse(Course course)
        {
            try
            {
                db.Entry(course).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool DeleteCourse(Course course)
        {
            try
            {
                db.Entry(course).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCourse(int courseId)
        {
            try
            {
                var cours = GetCourseById(courseId);
                DeleteCourse(cours);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }





        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
