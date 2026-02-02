using AssetManagement.Api.Models;
using AssetManagement.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : Controller
    {

        private readonly IAssetService _service;

        public AssetsController(IAssetService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssets()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAssetsById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssets([FromBody] AssetModel model)
        {
            var data = await _service.CreateAsync(model);
            return Ok(data);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAssets(int id, [FromBody] AssetModel model)
        {
            if (id != model.AssetId)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(model);
            return Ok(model);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAssets(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();

        }
    }
}
