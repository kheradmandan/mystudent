using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class User
    {
    
        public int Id { get; set; }
        public string UserName { get; set; } = default!;

        [ForeignKey("cI_Role")]
        public int CI_RoleId { get; set; }
        public virtual CI_Role? cI_Role { get; set; }

    }
}
