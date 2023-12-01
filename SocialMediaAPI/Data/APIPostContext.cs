using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Data
{
    public class APIPostContext : DbContext
    {
        
        public DbSet<UserPost> UsersPosts { get; set; }
        public APIPostContext(DbContextOptions<APIPostContext> options) : base(options)
        {

        }

    }
}
