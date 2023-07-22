using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class CI_FieldStudent
    {
        public CI_FieldStudent()
        {
            Students = new Collection<Student>();
        }
        public int Id { get; set; }
        public string? Title { get; set; } = default!;
        public virtual ICollection<Student> Students { get; set; }
    }
}
