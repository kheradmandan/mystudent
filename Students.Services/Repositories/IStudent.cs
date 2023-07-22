using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.Repositories
{
    public interface IStudent : IDisposable
    {
        IEnumerable<Student> GetAllStudents();
        int GetIdByUserName(string userName);
        Student GetStudentById(int StudentId);
        bool InsertStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student student);
        bool DeleteStudent(int studentId);
        void Save();
        public bool IExisitUserName(string username);
        IEnumerable<Student> GetStudentByIUserName(String username);
    }
}
