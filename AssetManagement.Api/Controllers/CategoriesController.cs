using AssetManagement.Api.Data;
using AssetManagement.Api.DTOs;
using AssetManagement.Api.Models;
using AssetManagement.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;
        public CategoriesController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }

        //Get: api/categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var data = await _CategoryService.GetAllAsync();

            var result = data.Select(c => new CategoryReadDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                AssetCount = c.Assets?.Count() ?? 0
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _CategoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var result = new CategoryReadDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                AssetCount = category.Assets?.Count() ?? 0
            };

            return Ok(result);
        }

        [HttpPost] 
        public async Task<IActionResult> CreateCategory(CategoryCreateDto model)
        {
            var categoryModel = new CategoryModel
            {
                CategoryName = model.CategoryName
            };

            var result = await _CategoryService.CreateAsync(categoryModel);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryCreateDto model)
        {
            var category = await _CategoryService.GetByIdAsync(id);

            if(category == null)
            {
                return NotFound();
            }
            
            category.CategoryName = model.CategoryName;
           
            await _CategoryService.UpdateAsync(category);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var Category = await _CategoryService.GetByIdAsync(id);

            if (Category == null)
                return NotFound();

            await _CategoryService.DeleteAsync(id);

            return Ok();
        }
    }
}
