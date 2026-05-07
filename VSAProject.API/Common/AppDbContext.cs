using Microsoft.EntityFrameworkCore;
using VSAProject.API.Domain;

namespace VSAProject.API.Common
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
}
