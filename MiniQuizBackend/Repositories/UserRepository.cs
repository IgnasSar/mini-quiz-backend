using Microsoft.EntityFrameworkCore;
using QuizAPI.Interfaces;
using QuizAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _databaseContext.Users.Add(user);
            await _databaseContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _databaseContext.Users.FindAsync(id);
            if (user == null)
                return false;

            _databaseContext.Users.Remove(user);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _databaseContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _databaseContext.Users.FindAsync(id);
        }

        public async Task<User> GetUserByNameAndEmailAsync(string name, string email)
        {
            return await _databaseContext.Users.FirstOrDefaultAsync(u => u.Name == name && u.Email == email);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _databaseContext.Entry(user).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserExistsAsync(int id)
        {
            return await _databaseContext.Users.AnyAsync(u => u.Id == id);
        }
    }
}
