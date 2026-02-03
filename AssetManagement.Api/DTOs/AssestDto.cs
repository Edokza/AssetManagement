using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Api.DTOs
{
    public class AssetCreateDto
    {
        [Required]
        public string AssetName { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }

    public class AssetReadDto
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string CategoryName { get; set; }
    }
}
