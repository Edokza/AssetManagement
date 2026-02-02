using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Api.Services
{
    public class AssetService
    {
        private readonly Data.AppDbContext _context;

        public AssetService(Data.AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.AssetModel>> GetAllAsync()
        {
            return await _context.Assets.Include(x => x.Category).ToListAsync();
        }

        public async Task<Models.AssetModel?> GetByIdAsync(int id)
        {
            return await _context.Assets.Include(x => x.Category).FirstOrDefaultAsync(x => x.AssetId == id);
        }

        public async Task<Models.AssetModel> CreateAsync(Models.AssetModel asset)
        {
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();
            return asset;
        }

        public async Task UpdateAsync(Models.AssetModel asset)
        {
            _context.Assets.Update(asset);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var asset = await _context.Assets.FindAsync(id);

            if (asset == null) {
                return;
            }

            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
        }
    }
}
