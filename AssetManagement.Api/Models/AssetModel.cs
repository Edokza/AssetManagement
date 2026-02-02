using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Api.Models
{
    public class AssetModel
    {
        public int AssetId { get; set; }
        [Required]
        public string AssetName { get; set; } = null!;
        public string AssetTag { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
