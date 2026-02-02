using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.AssetModel> Assets { get; set; } = null!;
        public DbSet<Models.CategoryModel> Categories { get; set; } = null!;
    }
}
