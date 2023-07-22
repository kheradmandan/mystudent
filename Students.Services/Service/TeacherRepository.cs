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
    public class TeacherRepository : ITeacher
    {

        private StudentDbContext db;
        public TeacherRepository(StudentDbContext _context)
        {
            this.db = _context;
        }
        public IEnumerable<Teacher> GetAllTeachers()
        {
            return db.Teachers.ToList();
        }

        public int GetIdByUserName(string userName)
        {
            if (db.Teachers.Where(p => p.UserName == userName).FirstOrDefault() == null)
            {
                return 0;
            }
            return db.Teachers.Where(p => p.UserName == userName).FirstOrDefault().Id;
        }


        public Teacher GetTeacherById(int teacherId)
        {
            return db.Teachers.Find(teacherId);
        }

        public IEnumerable<Teacher> GetTeacherByIUserName(String username)
        {
            return db.Teachers.Where(p => p.UserName == username).ToList();
        }


        public bool InsertTeacher(Teacher teacher)
        {
            try
            {
                db.Teachers.Add(teacher);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            try
            {
                db.Entry(teacher).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool DeleteTeacher(Teacher teacher)
        {
            try
            {
                db.Entry(teacher).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteTeacher(int teacherId)
        {
            try
            {
                var teacher = GetTeacherById(teacherId);
                DeleteTeacher(teacher);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public bool IExisitUserName(string username)
        {
            try
            {
                var student = db.Teachers.Where(p => p.UserName == username).FirstOrDefault();
                if (student != null)
                {
                    return true;
                }

                return false;
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

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
