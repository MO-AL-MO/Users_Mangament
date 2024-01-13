

using Users_Mangament.Application.DTOs.Request;
using Users_Mangament.Application.Interfaces.IService;
using Users_Mangament.Application.Interfaces.Repository.SupRepository;
using Users_Mangament.Domain.Models;

namespace Users_Mangament.Application.ServiceImp
{
    // PermissionService.cs
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<Permission> GetPermissionByIdAsync(int permissionId)
        {
            return await _permissionRepository.GetByIdAsync(permissionId);
        }

        public async Task<List<PermissionDTO>> GetAllPermissionsAsync()
        {
            var permissions = await _permissionRepository.GetAllAsync();
            return permissions.Select(p => new PermissionDTO { Id = p.Id, Name = p.Name }).ToList();
        }

        public async Task CreatePermissionAsync(Permission permission)
        {
            await _permissionRepository.AddAsync(permission);
        }

        public async Task UpdatePermissionAsync(Permission permission)
        {
            await _permissionRepository.UpdateAsync(permission);
        }

        public async Task DeletePermissionAsync(int permissionId)
        {
            await _permissionRepository.DeleteAsync(permissionId);
        }

        public async Task<List<Permission>> GetAllAsync()
        {
           var item= await _permissionRepository.GetAllAsync();
            return item.ToList();
        }

       


    }
}
