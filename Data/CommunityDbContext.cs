using Microsoft.EntityFrameworkCore;
using CommunityAPI.Models;

namespace CommunityAPI.Data
{
    public class CommunityDbContext : DbContext
    {
        public CommunityDbContext(DbContextOptions<CommunityDbContext> options) : base(options) { }

        public DbSet<Post> Post { get; set; }
        /*public DbSet<User> Users { get; set; }*/

    }
}
