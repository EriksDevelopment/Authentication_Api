using Authentication_Api.Data.Dtos;

namespace Authentication_Api.Core.Interfaces
{
    public interface IUserFriendService
    {
        Task<AddFriendResponseDto> AddFriendAsync(int currentUserId, string friendUserKey);
    }
}