using Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Data
{
    public class DBEntities : DbContext
    {
        public DBEntities(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfigration());


        }
        public void Commit()
        {
            base.SaveChanges();
        }
    }
}
