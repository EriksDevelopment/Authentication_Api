using Authentication_Api.Data.Dtos;

namespace Authentication_Api.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserLoginResponseDto> UserLoginAsync(UserLoginRequestDto dto);
    }
}