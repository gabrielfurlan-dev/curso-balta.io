using Furlan.dev.Data.Mappings;
using Furlan.dev.Models;
using Microsoft.EntityFrameworkCore;

namespace Furlan.dev.Data
{
    public class BlogDataContext : DbContext
    {
        IConfiguration config;

        public BlogDataContext(IConfiguration configuration)
            => config = configuration;

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql(config.GetConnectionString("DefaultConnection"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
        }
    }
}