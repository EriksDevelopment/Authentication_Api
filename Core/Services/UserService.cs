using Authentication_Api.Core.Interfaces;
using Authentication_Api.Core.Services.JwtServices;
using Authentication_Api.Data.Dtos;
using Authentication_Api.Data.Interfaces;
using Microsoft.Identity.Client;

namespace Authentication_Api.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly JwtService _jwt;
        public UserService(IUserRepository userRepo, JwtService jwt)
        {
            _userRepo = userRepo;
            _jwt = jwt;
        }

        public async Task<UserLoginResponseDto> UserLoginAsync(UserLoginRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.User_Name) ||
                string.IsNullOrWhiteSpace(dto.Password))
                throw new ArgumentException("Invalid, fields can't be empty.");

            var user = await _userRepo.GetUserByUserNameAsync(dto.User_Name);
            if (user == null || user.Password != dto.Password)
                throw new UnauthorizedAccessException("Invalid credentials.");

            var token = _jwt.GenerateToken(user.Id, "User");

            return new UserLoginResponseDto
            {
                AccessKey = token
            };
        }

        public async Task<UserInfoResponseDto> UserInfoAsync(int id)
        {
            var user = await _userRepo.GetUserByIdAsync(id);
            if (user == null)
                throw new ArgumentException("No user info found.");

            return new UserInfoResponseDto
            {
                User_Name = user.User_Name,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                PostalCode = user.PostalCode,
                City = user.PostalCode,
                Email = user.Email,
                Phone = user.Phone
            };
        }
    }
}