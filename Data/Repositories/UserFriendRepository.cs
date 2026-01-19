using Authentication_Api.Data.Interfaces;
using Authentication_Api.Data.Models;

namespace Authentication_Api.Data.Repositories
{
    public class UserFriendRepository : IUserFriendRepository
    {
        private readonly AuthenticationDbContext _context;
        public UserFriendRepository(AuthenticationDbContext context)
        {
            _context = context;
        }

        public async Task<UserFriend> AddFriendAsync(UserFriend userFriend)
        {
            _context.UserFriends.Add(userFriend);
            await _context.SaveChangesAsync();
            return userFriend;
        }
    }
}