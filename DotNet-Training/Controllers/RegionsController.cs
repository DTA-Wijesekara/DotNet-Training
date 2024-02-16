using AutoMapper;
using DotNet_Training.Context;
using DotNet_Training.CustomActionFilters;
using DotNet_Training.Models.Domains;
using DotNet_Training.Models.DTO;
using DotNet_Training.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly dasunDbcontext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(dasunDbcontext dbContext, IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        //get all regios
        //GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> Getall()
        { 
            logger.LogInformation("GetAllRegions Methord was started");
            var regionz = await regionRepository.GetAllAsync();
            var regionzDto = mapper.Map<List<RegionDTO>>(regionz);
            return Ok(regionzDto);
        }


        //get by ID
        //GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")] 
        public async Task<IActionResult> Getbyid([FromRoute]Guid id)
        {
            var regionz = await regionRepository.GetByIdAsync(id);
            if(regionz == null)
            {
                return NotFound();
            }
            var regionDto = mapper.Map<RegionDTO>(regionz);
            return Ok(regionDto);
        }


        //POST to create new region  
        //POST: https://localhost:portnumber/api/regions
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
                var regionDto = mapper.Map<RegionDTO>(regionDomainModel);
                return CreatedAtAction(nameof(Getbyid), new { id = regionDto.Id }, regionDto);
        }


        //Update region  
        //PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = await regionRepository.UpdateAsync(id, updateRegionRequestDto);        
            if (regionDomainModel == null)
            {
                return NotFound();
            };
            var regndto = mapper.Map<RegionDTO>(regionDomainModel);
            return Ok(regndto);
        }

        //Delete region  
        //DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);
            if(regionDomainModel == null)
            {
                return NotFound();
            };
            var regndto = mapper.Map<RegionDTO>(regionDomainModel);
            return Ok(regndto);
        }
    }
}
