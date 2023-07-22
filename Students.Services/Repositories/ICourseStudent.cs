using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.Repositories
{
    public interface ICourseStudent: IDisposable
    {
        IEnumerable<CourseStudent> GetAllCourseStudents();
        CourseStudent GetCourseStudentById(int id);
        IEnumerable<CourseStudent> GetCourseStudentByStudentId(int id);
        bool InsertCourseStudent(CourseStudent courseStudent);
        bool UpdateCourseStudent(CourseStudent courseStudent);
        bool DeleteCourseStudent(CourseStudent courseStudent);
        bool DeleteCourseStudent(int id);
         bool IsExistCourseIdCourseId(int CourseId, int studentId);
        IEnumerable<CourseStudent> GetCourseStudentByTeacheId(int id);
        IEnumerable<Student> GetStudentsByCoursId(int Coursid);
         int GetCourseStudentIdByStudentIdAndCoursId(int studentId, int courseId);
        void Save();
    }
}
