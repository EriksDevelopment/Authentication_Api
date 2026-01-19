using Authentication_Api.Data.Interfaces;
using Authentication_Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Api.Data.Repositories
{
    public class UserFriendRepository : IUserFriendRepository
    {
        private readonly AuthenticationDbContext _context;
        public UserFriendRepository(AuthenticationDbContext context)
        {
            _context = context;
        }

        public async Task AddFriendAsync(int userId, int friendId)
        {
            _context.UserFriends.AddRange
            (
                new UserFriend { UserId = userId, FriendId = friendId },
                new UserFriend { UserId = friendId, FriendId = userId }
            );
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AlreadyFriendsAsync(int userId, int friendId) =>
            await _context.UserFriends.AnyAsync(uf => uf.UserId == userId && uf.FriendId == friendId);
    }
}