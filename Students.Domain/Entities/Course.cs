using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Students.Domain.Entities
{
    public class Course
    {
        public Course()
        {
            CourseStudent = new Collection<CourseStudent>();
        }

        [Key]
        public int Id { get; set; }


        [Display(Name = "اسم کلاس")]

        public string? Title { get; set; } = default!;

        [Display(Name = "زمان برگزاری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Range(8, 17)]
        public int Classtime { get; set; } = default!;

        [Display(Name = "زمان هر جلسه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TimeOfSession { get; set; }


        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher? Teacher { get; set; }

        ////////////////////////

        public int CI_FieldCourseId { get; set; }

        [ForeignKey("CI_FieldCourseId")]
        public virtual CI_FieldCourse? CI_FieldCourse { get; set; }
        //////////////////////
        public virtual ICollection<CourseStudent> CourseStudent { get; set; }


    }
}

