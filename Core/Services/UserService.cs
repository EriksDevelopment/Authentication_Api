using Authentication_Api.Core.Interfaces;
using Authentication_Api.Core.Services.JwtServices;
using Authentication_Api.Data.Dtos;
using Authentication_Api.Data.Interfaces;
using Authentication_Api.Data.Models;
using BCrypt;


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
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
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

        public async Task<CreateUserResponseDto> CreateUserAsync(CreateUserRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.User_Name) ||
                string.IsNullOrWhiteSpace(dto.Password) ||
                string.IsNullOrWhiteSpace(dto.FirstName) ||
                string.IsNullOrWhiteSpace(dto.LastName) ||
                string.IsNullOrWhiteSpace(dto.Address) ||
                string.IsNullOrWhiteSpace(dto.PostalCode) ||
                string.IsNullOrWhiteSpace(dto.City) ||
                string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.Phone))
                throw new ArgumentException("Invalid, fields can't be empty.");


            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                User_Name = dto.User_Name,
                Password = hashedPassword,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                PostalCode = dto.PostalCode,
                City = dto.City,
                Email = dto.Email,
                Phone = dto.Phone
            };

            await _userRepo.CreateUserAsync(user);

            return new CreateUserResponseDto
            {
                Message = "User successfully created.",
                User_Name = dto.User_Name,
                Email = dto.Email
            };
        }

        public async Task<DeleteUserResponseDto> DeleteUserAsync(DeleteUserRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.Password))
                throw new ArgumentException("Invalid, fields can't be empty.");

            var user = await _userRepo.GetUserByEmailAsync(dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                throw new UnauthorizedAccessException("Invalid email or password.");

            await _userRepo.DeleteUserAsync(user);

            return new DeleteUserResponseDto
            {
                Message = $"User with username '{user.User_Name}' successfully deleted."
            };
        }
    }
}