using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Api.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; } = null!;
    }
}
