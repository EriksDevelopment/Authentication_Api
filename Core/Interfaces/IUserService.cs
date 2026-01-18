using Authentication_Api.Data.Dtos;

namespace Authentication_Api.Core.Services
{
    public interface IUserService
    {
        Task<UserLoginResponseDto> UserLoginAsync(UserLoginRequestDto dto);
    }
}