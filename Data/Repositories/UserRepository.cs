using System.Reflection.Metadata.Ecma335;
using Authentication_Api.Data.Interfaces;
using Authentication_Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Authentication_Api.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthenticationDbContext _context;
        public UserRepository(AuthenticationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByUserNameAsync(string userName) =>
            await _context.Users.FirstOrDefaultAsync(u => u.User_Name == userName);

        public async Task<User?> GetUserByIdAsync(int id) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByEmailAsync(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User> DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserNameExistsAsync(string userName) =>
            await _context.Users.AnyAsync(u => u.User_Name == userName);

        public async Task<bool> EmailExistsAsync(string email) =>
            await _context.Users.AnyAsync(u => u.Email == email);

        public async Task<bool> UserKeyExistsAsync(string userKey) =>
            await _context.Users.AnyAsync(u => u.UserKey == userKey);

        public async Task<User?> GetFriendByUserKeyAsync(string userKey) =>
            await _context.Users.FirstOrDefaultAsync(u => u.UserKey == userKey);

        public async Task<List<User>> GetFriendByUserIdAsync(int userId) =>
            await _context.UserFriends
                .Where(uf => uf.UserId == uf.FriendId)
                .Select(uf => uf.Friend)
                .ToListAsync();
    }
}