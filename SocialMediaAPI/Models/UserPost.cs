namespace SocialMediaAPI.Models
{
    public class UserPost
    {
        public long PostId { get; set; } // primary key for database
        public int UploderId { get; set; } //foreign key                            !!!!!?      
        public string? Title { get; set; }


        public string Text { get; set; }
        public string ImageUrl { get; set; }
        
    }
}
