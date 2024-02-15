using AutoMapper;
using DotNet_Training.Models.Domains;
using DotNet_Training.Models.DTO;
using DotNet_Training.Models.DTO.DifficultyDtos;
using DotNet_Training.Models.DTO.walksDtos;

namespace DotNet_Training.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region,RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequestDto,Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto,Region>().ReverseMap();
            CreateMap<AddWalkDto,Walk>().ReverseMap();
            CreateMap<WalkDto,Walk>().ReverseMap();
            CreateMap<DifficultyDto,Difficulty>().ReverseMap();

        }
    }
}
