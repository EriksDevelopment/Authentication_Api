using Authentication_Api.Data.Dtos;

namespace Authentication_Api.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserLoginResponseDto> UserLoginAsync(UserLoginRequestDto dto);

        Task<UserInfoResponseDto> UserInfoAsync(int id);

        Task<CreateUserResponseDto> CreateUserAsync(CreateUserRequestDto dto);

        Task<DeleteUserResponseDto> DeleteUserAsync(DeleteUserRequestDto dto);
    }
}