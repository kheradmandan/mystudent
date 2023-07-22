using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.Repositories
{
    public interface ICI_FieldCourse: IDisposable
    {
        IEnumerable<CI_FieldCourse> GetAllCI_FieldCourses();
        CI_FieldCourse GetCI_FieldCourseById(int cI_FieldCourseId);
        bool InsertCI_FieldCourse(CI_FieldCourse cI_FieldCourse);
        bool UpdateCI_FieldCourse(CI_FieldCourse cI_FieldCourse);
        bool DeleteCI_FieldCourse(CI_FieldCourse cI_FieldCourse);
        bool DeleteCI_FieldCourse(int cI_FieldCourse);
        void Save();
    }
}
