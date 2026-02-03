using AssetManagement.Api.DTOs;
using AssetManagement.Api.Models;
using AssetManagement.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : Controller
    {

        private readonly IAssetService _AssetService;

        public AssetsController(IAssetService AssetService)
        {
            _AssetService = AssetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssets()
        {
            var data = await _AssetService.GetAllAsync();

            var result = data.Select(a => new AssetReadDto
            {
                AssetId = a.AssetId,
                AssetName = a.AssetName,
                SerialNumber = a.SerialNumber,
                CategoryName = a.Category.CategoryName
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssetsById(int id)
        {
            var data = await _AssetService.GetByIdAsync(id);

            if(data == null)
            {
                return NotFound();
            }

            var result = new AssetReadDto
            {
                AssetId = data.AssetId,
                AssetName = data.AssetName,
                SerialNumber = data.SerialNumber,
                CategoryName = data.Category.CategoryName,
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssets(AssetCreateDto model)
        {
            var asset = new AssetModel
            {
                AssetName = model.AssetName,
                SerialNumber = model.SerialNumber,
                CategoryId = model.CategoryId
            };


            var data = await _AssetService.CreateAsync(asset);
            return Ok(data);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssets(int id, AssetModel model)
        {
            if (id != model.AssetId)
            {
                return BadRequest();
            }

            await _AssetService.UpdateAsync(model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssets(int id)
        {
            var Asset = await _AssetService.GetByIdAsync(id);

            if (Asset == null)
                return NotFound();

            await _AssetService.DeleteAsync(id);
            return NoContent();

        }
    }
}
