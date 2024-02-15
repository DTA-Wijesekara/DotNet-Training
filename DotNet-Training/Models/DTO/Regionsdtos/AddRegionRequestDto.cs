using System.ComponentModel.DataAnnotations;

namespace DotNet_Training.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MaxLength(5,ErrorMessage ="max")]
        [MinLength(3,ErrorMessage ="min")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
