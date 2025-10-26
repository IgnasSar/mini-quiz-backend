using QuizAPI.Interfaces;
using QuizAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateOrGetUserAsync(User user)
        {
            var existingUser = await _userRepository.GetUserByNameAndEmailAsync(user.Name, user.Email);
            if (existingUser != null) return existingUser;

            return await _userRepository.AddUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            if (id != user.Id)
                return null;

            var exists = await _userRepository.UserExistsAsync(id);

            if (!exists)
                return null;

            return await _userRepository.UpdateUserAsync(user);
        }
    }
}
