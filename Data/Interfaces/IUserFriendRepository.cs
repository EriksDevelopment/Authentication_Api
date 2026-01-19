using Authentication_Api.Data.Models;

namespace Authentication_Api.Data.Interfaces
{
    public interface IUserFriendRepository
    {
        Task<UserFriend> AddFriendAsync(UserFriend userFriend);
    }
}