using System.ComponentModel.DataAnnotations;

namespace DotNet_Training.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        [Required]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
