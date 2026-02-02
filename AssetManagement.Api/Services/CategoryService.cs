using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly Data.AppDbContext _context;

        public CategoryService(Data.AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.CategoryModel>> GetAllAsync()
        {
            return await _context.Categories.Include(c => c.Assets).ToListAsync();
        }

        public async Task<Models.CategoryModel?> GetByIdAsync(int id)
        {
            return await _context.Categories.Include(c => c.Assets).FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<Models.CategoryModel> CreateAsync(Models.CategoryModel category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task UpdateAsync(Models.CategoryModel category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null) {
                return;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
