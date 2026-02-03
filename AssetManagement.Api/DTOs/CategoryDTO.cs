using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Api.DTOs
{
    public class CategoryCreateDto
    {
        [Required]
        public string CategoryName { get; set; }
    }
    public class CategoryReadDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int AssetCount { get; set; }
    }
}
