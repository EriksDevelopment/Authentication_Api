using Authentication_Api.Data.Models;

namespace Authentication_Api.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUserNameAsync(string username);
    }
}