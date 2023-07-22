using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class CI_FieldCourse
    {
        /// <summary>
        /// / return View ("~/Areas/Admin/Views/Home/index.cshtml");
        /// 
        /// </summary>
        public CI_FieldCourse()
        {
            Courses = new Collection<Course>();
        }
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; } = default!;
        public virtual ICollection<Course> Courses { get; set; }

    }
}
