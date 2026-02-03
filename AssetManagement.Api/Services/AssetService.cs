using AssetManagement.Api.Exceptions;
using AssetManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Api.Services
{
    public class AssetService : IAssetService
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
            var Asset = await _context.Assets.Include(x => x.Category).FirstOrDefaultAsync(x => x.AssetId == id);

            if(Asset == null)
            {
                throw new NotFoundException($"Asset with ID {id} not found.");
            }

            return Asset;
        }

        public async Task<AssetModel> CreateAsync(AssetModel asset)
        {
            if (!await _context.Categories.AnyAsync(x => x.CategoryId == asset.CategoryId))
                throw new BadRequestException("Invalid CategoryId");

            if (await _context.Assets.AnyAsync(x => x.AssetName == asset.AssetName))
                throw new BadRequestException("Asset name already exists");


            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();
            return asset;
        }

        public async Task UpdateAsync(AssetModel asset)
        {
            _context.Assets.Update(asset);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var asset = await _context.Assets.FindAsync(id);

            if (asset == null) {
                throw new NotFoundException($"Asset with ID {id} not found.");
            }

            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
        }
    }
}
