

using Users_Mangament.Application.DTOs.Request;
using Users_Mangament.Application.Interfaces.IService;
using Users_Mangament.Application.Interfaces.Repository.SupRepository;
using Users_Mangament.Domain.Models;

namespace Users_Mangament.Application.ServiceImp
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;

        public RoleService(IRoleRepository roleRepository, IPermissionRepository permissionRepository)
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
          
        }

        public async Task<Role?> GetRoleByIdAsync(int roleId)
        {
            return await _roleRepository.GetRolewithPermissionByIdAsync(roleId);
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        //public async Task CreateRoleAsync(Role role)
        //{
        //    await _roleRepository.AddAsync(role);
        //}

        public async Task UpdateRoleAsync(Role role)
        {
            await _roleRepository.UpdateAsync(role);
        }

        public async Task DeleteRoleAsync(int roleId)
        {
            await _roleRepository.DeleteAsync(roleId);
        }

       

        public async Task AddRoleWithPermissionsAsync(Role role, List<int> permissionIds)
        {
            // إضافة الدور
            var addedRole = await _roleRepository.AddAsync(role);

            // جلب الصلاحيات المحددة
            var permissions = await _roleRepository.GetPermissionsByIdsAsync(permissionIds);

            // تعيين الصلاحيات للدور
            foreach (var permission in permissions)
            {
                addedRole.RolePermissions.Add(new RolePermission { RoleId = addedRole.Id, PermissionId = permission.Id });
            }

            // تحديث الدور بالصلاحيات
            await _roleRepository.UpdateAsync(addedRole);
        }



        public async Task CreateRoleAsync(RoleDTO roleDTO)
        {
            // إنشاء دور جديد
            var role = new Role { Name = roleDTO.Name };

            // إضافة الدور إلى قاعدة البيانات
            await _roleRepository.AddAsync(role);

            // جلب الصلاحيات المحددة من قاعدة البيانات
            var permissions = await _roleRepository.GetPermissionsByIdsAsync(roleDTO.SelectedPermissionIds);

            // ربط الصلاحيات بالدور
            role.RolePermissions = permissions.Select(permission => new RolePermission { RoleId = role.Id, PermissionId = permission.Id }).ToList();

            // تحديث الدور بالصلاحيات
            await _roleRepository.UpdateAsync(role);
        }

        public async Task UpdateRoleAsync(RoleDTO role)
        {
            // قم بالتحقق هنا من صحة البيانات أو أي قواعد أعمال أخرى قبل تحديث الدور

            // استرجاع الدور من قاعدة البيانات
            var existingRole = await _roleRepository.GetByIdAsync(role.Id);

            if (existingRole == null)
            {
                // يمكنك رمي استثناء أو إجراء إجراء مناسب هنا إذا لم يتم العثور على الدور
                throw new Exception($"Role with Id {role.Id} not found.");
            }

            // قم بتحديث الخصائص الخاصة بالدور من معلومات نموذج الـ DTO
            existingRole.Name = role.Name;
           

            // تحديث الصلاحيات
            // يجب عليك تنظيف الصلاحيات الحالية وإضافة الجديدة
            existingRole.RolePermissions.Clear();

            foreach (var permissionId in role.SelectedPermissionIds)
            {
                // يمكنك تنفيذ طلب إلى الـ repository لاسترجاع الصلاحية من قاعدة البيانات
                var permission = await _permissionRepository.GetByIdAsync(permissionId);

                if (permission != null)
                {
                    // إضافة الصلاحية إلى الدور
                    existingRole.RolePermissions.Add(new RolePermission { Permission = permission });
                }
               
            }

            // حفظ التغييرات في قاعدة البيانات
            await _roleRepository.UpdateAsync(existingRole);
        }

        

    }
}
