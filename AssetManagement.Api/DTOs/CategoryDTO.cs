using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Api.DTOs
{
    public class CategoryCreateDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Category name must be between 2 and 50 characters")]
        [RegularExpression(@".*\S+.*", ErrorMessage = "Category name cannot be empty or whitespace")]
        public string CategoryName { get; set; }
    }
    public class CategoryReadDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int AssetCount { get; set; }
    }
}
