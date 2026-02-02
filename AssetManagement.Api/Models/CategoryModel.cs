using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Api.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; } = null!;
        public ICollection<AssetModel> Assets { get; set; } = new List<AssetModel>();
    }
}
