namespace Authentication_Api.Data.Models
{
    public class User
    {
        public int Id { get; set; }
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
}