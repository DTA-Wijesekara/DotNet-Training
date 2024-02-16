using AutoMapper;
using DotNet_Training.CustomActionFilters;
using DotNet_Training.Models.Domains;
using DotNet_Training.Models.DTO;
using DotNet_Training.Models.DTO.walksDtos;
using DotNet_Training.Repositories;
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
        [ValidateModel]
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
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var WalkDomainModel = await walkRepository.GetByIdAsync(id);
            if (WalkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(WalkDomainModel));
        }
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkDto WalkDto)
        {
            var www = mapper.Map<Walk>(WalkDto);
            var WalkDomainModel = await walkRepository.UpdateAsync(id,www);
            if (WalkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(WalkDomainModel));
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await walkRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            };
            var regndto = mapper.Map<WalkDto>(regionDomainModel);
            return Ok(regndto);
        }
    }
}
