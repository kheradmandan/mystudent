using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.Repositories
{
    public interface ITeacher : IDisposable
    {
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetTeacherById(int teacherId);
        bool InsertTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
        bool DeleteTeacher(Teacher teacher);
        bool DeleteTeacher(int teacherId);
        IEnumerable<Teacher> GetTeacherByIUserName(String username);
         int GetIdByUserName(string userName);
        bool IExisitUserName(string username);
        void Save();
    }
}
