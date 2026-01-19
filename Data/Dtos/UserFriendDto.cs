namespace Authentication_Api.Data.Dtos
{
    public class AddFriendRequestDto
    {
        public string Friend_User_Key { get; set; } = null!;
    }

    public class AddFriendResponseDto
    {
        public string Message { get; set; } = null!;
    }
}