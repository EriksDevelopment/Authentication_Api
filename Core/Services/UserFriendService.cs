using Authentication_Api.Core.Interfaces;
using Authentication_Api.Data.Dtos;
using Authentication_Api.Data.Interfaces;
using Authentication_Api.Data.Models;

namespace Authentication_Api.Core.Services
{
    public class UserFriendService : IUserFriendService
    {
        private readonly IUserFriendRepository _userFriendRepo;
        private readonly IUserRepository _userRepo;
        public UserFriendService(IUserFriendRepository userFriendRepo, IUserRepository userRepo)
        {
            _userFriendRepo = userFriendRepo;
            _userRepo = userRepo;
        }
        public async Task<AddFriendResponseDto> AddFriendAsync(int currentUserId, string friendUserKey)
        {
            if (string.IsNullOrWhiteSpace(friendUserKey))
                throw new ArgumentException("Invalid, user key can't be empty. (ex. #12345)");

            var friend = await _userRepo.GetFriendByUserKeyAsync(friendUserKey);


            if (friend == null)
                throw new ArgumentException($"No user found with user key: {friendUserKey}");

            var currentUser = await _userRepo.GetUserByIdAsync(currentUserId);
            if (currentUser == null)
                throw new ArgumentException("Current user not found.");

            if (await _userFriendRepo.AlreadyFriendsAsync(currentUserId, friend.Id))
                throw new ArgumentException("Already your friend.");


            await _userFriendRepo.AddFriendAsync(currentUserId, friend.Id);

            return new AddFriendResponseDto
            {
                Message = $"You have added '{friend.User_Name} as your friend.'"
            };
        }
    }
}