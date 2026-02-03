using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AssetManagement.Api.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; } = null!;
        [JsonIgnore]
        public ICollection<AssetModel> Assets { get; set; } = new List<AssetModel>();
    }
}
