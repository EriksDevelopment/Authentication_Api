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
}