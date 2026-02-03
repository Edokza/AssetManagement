using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AssetManagement.Api.Models
{
    public class AssetModel
    {
        [Key]
        public int AssetId { get; set; }
        [Required]
        public string AssetName { get; set; } = null!;
        // Foreign Key
        public int CategoryId { get; set; }
        // Navigation Property
        [ForeignKey("CategoryId")]
        [JsonIgnore]
        public CategoryModel? Category { get; set; }
    }
}
