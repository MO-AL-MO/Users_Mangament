

using Users_Mangament.Application.DTOs.Request;
using Users_Mangament.Domain.Models;

namespace Users_Mangament.Application.Interfaces.IService
{
    // Services/IUserService.cs
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);

        //Task<User> GetUserByUsernameAsync(string username);
        //Task<User> GetUserByEmailAsync(string email);
    }
}
