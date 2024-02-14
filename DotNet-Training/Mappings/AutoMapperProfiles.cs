using AutoMapper;
using DotNet_Training.Models.Domains;
using DotNet_Training.Models.DTO;

namespace DotNet_Training.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region,RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequestDto,Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto,Region>().ReverseMap();

        }
    }
}
