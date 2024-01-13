using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_Mangament.Domain.Models;

namespace Users_Mangament.Application.Interfaces.Repository.SupRepository
{
    public interface IRoleRepository : IRepository<Role>
    {
        //Task<Role> GetByNameAsync(string roleName);
        Task<IEnumerable<Role>> GetRolesWithPermissionsAsync();
        Task<List<Permission>> GetPermissionsByIdsAsync(List<int> permissionIds);
        Task<Role?> GetRolewithPermissionByIdAsync(int id);
        Task AddRoleWithPermissionsAsync(Role role, List<int> permissionIds);
    }
}
