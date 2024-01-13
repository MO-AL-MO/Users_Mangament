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
    public class UserRepository : Repository<User>, IUserRepository
    {
       

        public UserRepository(ApplicationDbContext context) : base(context)
        {
          
        }

        public async Task<IEnumerable<User>> GetUsersWithRolesAsync()
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .ToListAsync();
        }

        //public async Task<User> GetByUsernameAsync(string username)
        //{
        //    return await _context.Set<User>().FirstOrDefaultAsync(u => u.UserName == username);
        //}

        //public async Task<User> GetByEmailAsync(string email)
        //{
        //    return await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        //}

    }
}
