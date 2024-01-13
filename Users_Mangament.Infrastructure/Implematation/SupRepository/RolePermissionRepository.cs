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
    public class RolePermissionRepository : Repository<RolePermission>, IRolePermissionRepository
    {
        public RolePermissionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Permission>> GetPermissionsByRoleIdAsync(int roleId)
        {
            var item = await _context.Set<RolePermission>()
                .Where(rp => rp.RoleId == roleId)
                .Select(rp => rp.Permission)
                .ToListAsync();
            return item;
        }

    }
}
