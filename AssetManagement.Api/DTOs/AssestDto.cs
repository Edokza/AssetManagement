using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Api.DTOs
{
    public class AssetCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3,ErrorMessage = "Asset name must be between 3 and 100 characters")]
        [RegularExpression(@".*\S+.*", ErrorMessage = "Asset name cannot be empty or whitespace")]
        public string AssetName { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^$|.*\S+.*",
        ErrorMessage = "Serial number cannot be whitespace")]
        public string? SerialNumber { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be greater than 0")]
        public int CategoryId { get; set; }
    }

    public class AssetReadDto
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? SerialNumber { get; set; }
    }
}
