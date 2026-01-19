using Microsoft.EntityFrameworkCore;

namespace Authentication_Api.Data.Models
{

    [Index(nameof(User_Name), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        public string User_Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserKey { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public ICollection<UserFriend> Friends { get; set; } = new List<UserFriend>();
    }
}