using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Models;


namespace SocialMediaAPI.Data
{
    public class APIContext : DbContext //database context
    {

        public DbSet<UserAccount> MyAccount { get; set; }   
       public APIContext(DbContextOptions<APIContext> options) : base (options){

        }
    }
}
