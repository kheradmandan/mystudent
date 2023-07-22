using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.Repositories
{
    public interface ICI_Role
    {
        IEnumerable<CI_Role> GetAllCI_Role();
        CI_Role GetCI_RoleById(int cI_RoleId);
        bool InsertCI_Role(CI_Role cI_Role);
        bool UpdateCI_Role(CI_Role cI_Role);
        bool DeleteCI_Role(CI_Role cI_Role);
        bool DeleteCI_Role(int cI_Role);
        void Save();
    }
}
