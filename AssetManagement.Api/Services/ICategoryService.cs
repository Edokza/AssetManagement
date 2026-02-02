using AssetManagement.Api.Models;

namespace AssetManagement.Api.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetAllAsync();
        Task<CategoryModel?> GetByIdAsync(int id);
        Task<CategoryModel> CreateAsync(CategoryModel category);
        Task UpdateAsync(CategoryModel category);
        Task DeleteAsync(int id);
    }
}
