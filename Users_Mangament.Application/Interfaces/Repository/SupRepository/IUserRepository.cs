using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_Mangament.Domain.Models;

namespace Users_Mangament.Application.Interfaces.Repository.SupRepository
{
    public interface IUserRepository : IRepository<User>
    {
        //Task<User> GetByUsernameAsync(string username);
        //Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetUsersWithRolesAsync();

    }
}
