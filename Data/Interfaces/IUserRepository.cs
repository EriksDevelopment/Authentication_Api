using Authentication_Api.Data.Models;

namespace Authentication_Api.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUserNameAsync(string userName);

        Task<User?> GetUserByIdAsync(int id);

        Task<User> CreateUserAsync(User user);

        Task<User?> GetUserByEmailAsync(string email);

        Task<User> DeleteUserAsync(User user);
    }
}