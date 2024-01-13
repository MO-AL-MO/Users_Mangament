

using Users_Mangament.Application.DTOs.Request;
using Users_Mangament.Domain.Models;

namespace Users_Mangament.Application.Interfaces.IService
{
    public interface IPermissionService
    {
        Task<Permission> GetPermissionByIdAsync(int permissionId);
        Task<List<PermissionDTO>> GetAllPermissionsAsync();
        Task<List<Permission>> GetAllAsync();

        Task CreatePermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
        Task DeletePermissionAsync(int permissionId);

    }
}
