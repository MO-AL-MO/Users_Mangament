using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_Mangament.Domain.Models;

namespace Users_Mangament.Application.Interfaces.Repository.SupRepository
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Task<IEnumerable<Permission>> GetPermissionsWithRolesAsync();
   
    }
}
