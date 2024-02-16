using System.ComponentModel.DataAnnotations;

namespace DotNet_Training.Models.DTO.walksDtos
{
    public class AddWalkDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
