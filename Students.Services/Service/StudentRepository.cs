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
    public class StudentRepository : IStudent
    {
        private StudentDbContext db;
        public StudentRepository(StudentDbContext _context)
        {
            this.db = _context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return db.Students.ToList();
        }

        public Student GetStudentById(int StudentId)
        {
            return db.Students.Find(StudentId);
        }

        public IEnumerable<Student> GetStudentByIUserName(String username)
        {
            return db.Students.Where(p=> p.UserName == username ).ToList();
        }

        public bool InsertStudent(Student student)
        {
            try
            {
                db.Students.Add(student);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                db.Entry(student).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


        public bool DeleteStudent(Student student)
        {
            try
            {
                db.Entry(student).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteStudent(int studentId)
        {
            try
            {
                var student = GetStudentById(studentId);
                DeleteStudent(student);
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
                var student = db.Students.Where(p => p.UserName == username).FirstOrDefault();
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


        public int GetIdByUserName(string userName)
        {
            if(db.Students.Where(p => p.UserName == userName).FirstOrDefault() == null)
            {
                return 0;
            }
            return db.Students.Where(p=>p.UserName== userName ).FirstOrDefault().Id;
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
