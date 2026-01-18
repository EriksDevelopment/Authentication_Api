using Authentication_Api.Data.Interfaces;
using Authentication_Api.Data.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}