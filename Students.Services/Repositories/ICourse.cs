using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.Repositories
{
    public interface ICourse : IDisposable
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int courseId);
        bool InsertCourse(Course course);
        bool UpdateCourse(Course course);
        bool DeleteCourse(Course course);
        bool DeleteCourse(int courseId);
        void Save();
    }
}
