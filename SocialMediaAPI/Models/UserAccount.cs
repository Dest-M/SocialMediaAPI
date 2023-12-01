namespace SocialMediaAPI.Models
{
    public class UserAccount
    {
        public int Id { get; set; } // primary key for database
        public string? Username { get; set; }
        public string? Password { get; set; }

    }
}
