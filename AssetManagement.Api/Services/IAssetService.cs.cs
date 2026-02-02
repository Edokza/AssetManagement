using AssetManagement.Api.Models;

namespace AssetManagement.Api.Services
{
    public interface IAssetService
    {
        Task<List<AssetModel>> GetAllAsync();
        Task<AssetModel?> GetByIdAsync(int id);
        Task<AssetModel> CreateAsync(AssetModel asset);
        Task UpdateAsync(AssetModel asset);
        Task DeleteAsync(int id);
    }
}
