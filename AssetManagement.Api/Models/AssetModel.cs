using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.Api.Models
{
    public class AssetModel
    {
        [Key]
        public int AssetId { get; set; }
        [Required]
        public string AssetName { get; set; } = null!;
        public string AssetTag { get; set; } = null!;
        // Foreign Key
        public int CategoryId { get; set; }
        // Navigation Property
        [ForeignKey("CategoryId")]
        public CategoryModel? Category { get; set; }
    }
}
