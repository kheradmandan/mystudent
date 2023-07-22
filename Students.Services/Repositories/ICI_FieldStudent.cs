using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.Repositories
{
    public interface ICI_FieldStudent: IDisposable
    {
        IEnumerable<CI_FieldStudent> GetAllCI_FieldStudents();
        CI_FieldStudent GetCI_FieldStudentById(int cI_FieldStudentId);
        bool InsertCI_FieldStudent(CI_FieldStudent cI_FieldStudent);
        bool UpdateCI_FieldStudent(CI_FieldStudent cI_FieldStudent);
        bool DeleteCI_FieldStudent(CI_FieldStudent cI_FieldStudent);
        bool DeleteCI_FieldStudent(int cI_FieldStudent);
        void Save();
    }
}
