namespace Authentication_Api.Data.Interfaces
{
    public interface IUserFriendRepository
    {
        Task AddFriendAsync(int userId, int friendId);

        Task<bool> AlreadyFriendsAsync(int userId, int friendId);
    }
}