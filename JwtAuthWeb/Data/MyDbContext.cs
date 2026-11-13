
using JwtAuthWeb.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthWeb.Data
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
    }
}
