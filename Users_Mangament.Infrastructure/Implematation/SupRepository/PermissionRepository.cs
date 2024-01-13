using Messaia.Net.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_Mangament.Application.Interfaces.Repository.SupRepository;
using Users_Mangament.Domain.Models;
using Users_Mangament.Infrastructure.Data;

namespace Users_Mangament.Infrastructure.Implematation.SupRepository
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Permission>> GetPermissionsWithRolesAsync()
        {
            return await _context.Permissions
                .Include(p => p.RolePermissions)
                    .ThenInclude(rp => rp.Role)
                .ToListAsync();
        }
        //public async Task<Permission> GetByNameAsync(string permissionName)
        //{
        //    return await _context.Set<Permission>().FirstOrDefaultAsync(p => p.Name == permissionName);
        //}
       
        public async Task<IEnumerable<Permission>> GetPermissionsByRoleIdAsync(int roleId)
        {
            var role = await _context.Roles
                .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(r => r.Id == roleId);

            return role?.RolePermissions.Select(rp => rp.Permission);
        }
    }
}
