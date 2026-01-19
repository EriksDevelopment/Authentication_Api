namespace Authentication_Api.Data.Dtos
{
    public class UserLoginRequestDto
    {
        public string User_Name { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class UserLoginResponseDto
    {
        public string AccessKey { get; set; } = null!;
    }

    public class UserInfoResponseDto
    {
        public string UserKey { get; set; } = null!;
        public string User_Name { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }

    public class CreateUserRequestDto
    {
        public string User_Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }

    public class CreateUserResponseDto
    {
        public string Message { get; set; } = null!;
        public string User_Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class DeleteUserRequestDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class DeleteUserResponseDto
    {
        public string Message { get; set; } = null!;
    }
}