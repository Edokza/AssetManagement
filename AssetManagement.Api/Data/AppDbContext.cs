using AssetManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<AssetModel> Assets { get; set; } = null!;
        public DbSet<CategoryModel> Categories { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { CategoryId = 1, CategoryName = "Laptop" },
                new CategoryModel { CategoryId = 2, CategoryName = "Monitor" },
                new CategoryModel { CategoryId = 3, CategoryName = "Keyboard" },
                new CategoryModel { CategoryId = 4, CategoryName = "Mouse" },
                new CategoryModel { CategoryId = 5, CategoryName = "Headphone" }
            );
        }
    }
}
