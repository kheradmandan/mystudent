using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Students.Domain.Entities
{
    public class Teacher
    {
        public Teacher()
        {
            Courses = new Collection<Course>();
            Users = new Collection<User>();
        }
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام کاربری")]
        public string? UserName { get; set; }

        [Display(Name = " نام کامل معلم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; } = "";
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]

        [RegularExpression(@"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$", ErrorMessage = "فرمت شماره همراه باید درست باشد ")]
        public string Mob { get; set; } = "";



        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
