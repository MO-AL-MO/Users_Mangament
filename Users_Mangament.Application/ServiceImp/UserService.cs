
using Users_Mangament.Application.DTOs.Request;
using Users_Mangament.Application.Interfaces.IService;
using Users_Mangament.Application.Interfaces.Repository.SupRepository;
using Users_Mangament.Domain.Models;

namespace Users_Mangament.Application.ServiceImp
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteAsync(userId);
        }

        //public async Task<User> GetUserByUsernameAsync(string username)
        //{
        //    return await _userRepository.GetByUsernameAsync(username);
        //}

        //public async Task<User> GetUserByEmailAsync(string email)
        //{
        //    return await _userRepository.GetByEmailAsync(email);
        //}
    }
}



    
