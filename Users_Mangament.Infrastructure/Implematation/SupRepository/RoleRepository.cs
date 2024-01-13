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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Role>> GetRolesWithPermissionsAsync()
        {
            return await _context.Roles
                .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .ToListAsync();
        }
        public async Task<List<Permission>> GetPermissionsByIdsAsync(List<int> permissionIds)
        {
            return await _context.Permissions.Where(p => permissionIds.Contains(p.Id)).ToListAsync();
        }
        public async Task AddRoleWithPermissionsAsync(Role role, List<int> permissionIds)
        {
            _context.Roles.Add(role);

            foreach (var permissionId in permissionIds)
            {
                role.RolePermissions.Add(new RolePermission
                {
                    PermissionId = permissionId
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Role?> GetRolewithPermissionByIdAsync(int id)
        {
            return await _context.Roles
                .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
