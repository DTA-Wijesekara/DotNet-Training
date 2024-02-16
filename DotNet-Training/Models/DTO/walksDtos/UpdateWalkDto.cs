using System.ComponentModel.DataAnnotations;

namespace DotNet_Training.Models.DTO.walksDtos
{
    public class UpdateWalkDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
