

using Users_Mangament.Application.DTOs.Request;
using Users_Mangament.Domain.Models;

namespace Users_Mangament.Application.Interfaces.IService
{
    public interface IRoleService
    {
        
        Task CreateRoleAsync(RoleDTO roleDTO);
        Task<Role?> GetRoleByIdAsync(int roleId);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task AddRoleWithPermissionsAsync(Role role, List<int> permissionIds);

        Task UpdateRoleAsync(RoleDTO role);
        Task DeleteRoleAsync(int roleId);



    }
}
