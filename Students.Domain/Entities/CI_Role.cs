using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class CI_Role
    {
        public CI_Role()
        {
            Users = new Collection<User>();
        }
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; } = default!;
        public virtual ICollection<User> Users { get; set; }
    }
}
