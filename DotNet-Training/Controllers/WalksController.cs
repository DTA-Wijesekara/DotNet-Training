using AutoMapper;
using DotNet_Training.Models.Domains;
using DotNet_Training.Models.DTO.walksDtos;
using DotNet_Training.Repositories.WalkServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper , IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkDto addWalkDto)
        {
            var WalkDomainModel = mapper.Map<Walk>(addWalkDto);
            await walkRepository.CreateAsync(WalkDomainModel);
            return Ok(mapper.Map<WalkDto>(WalkDomainModel));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var WalkDomainModel =await walkRepository.GetAllAsync();
            return Ok(mapper.Map<List<WalkDto>>(WalkDomainModel));
        }
    }
}
