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
    public class CourseStudentRepository : ICourseStudent
    {
        private StudentDbContext db;
        public CourseStudentRepository(StudentDbContext _context)
        {
            this.db = _context;
        }

        public IEnumerable<Student> GetStudentsByCoursId(int Coursid)
        {
            IList<Student> studentsList =  new List<Student>();
            var coursStudentList = db.CourseStudents.Where(p => p.CourseId == Coursid).ToList();
            foreach (var item in coursStudentList)
            {
                studentsList.Add(item.Students);
            }
            return studentsList;
      
        }

        public int GetCourseStudentIdByStudentIdAndCoursId(int studentId, int courseId)
        {
            return db.CourseStudents.Where(p => p.CourseId == courseId && p.StudentId == studentId).ToList().FirstOrDefault().Id;
        }
        public IEnumerable<CourseStudent> GetAllCourseStudents()
        {
            return db.CourseStudents.ToList();
        }

        public CourseStudent GetCourseStudentById(int id)
        {
            // return db.CourseStudents.Where(p => p.Id == id).ToList();
            return db.CourseStudents.Find(id);

        }
        public IEnumerable<CourseStudent> GetCourseStudentByStudentId(int id)
        {
            return db.CourseStudents.Where(p => p.StudentId == id).ToList();
        }

        public IEnumerable<CourseStudent> GetCourseStudentByTeacheId(int id)
        {

            return db.CourseStudents.Where(p => p.courses.TeacherId == id).ToList();
        }

        public bool InsertCourseStudent(CourseStudent courseStudent)
        {
            try
            {
                db.CourseStudents.Add(courseStudent);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdateCourseStudent(CourseStudent courseStudent)
        {
            try
            {
                db.ChangeTracker.Clear();
                db.Entry(courseStudent).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCourseStudent(CourseStudent courseStudent)
        {
            try
            {
                db.Entry(courseStudent).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCourseStudent(int id)
        {
            try
            {
                var coursstudent = GetCourseStudentById(id);
                DeleteCourseStudent(coursstudent);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool IsExistCourseIdCourseId(int CourseId, int studentId)
        {
            return db.CourseStudents.Any(p => p.CourseId == CourseId && p.StudentId == studentId);
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
