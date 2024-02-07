using DotNet_Training.Context;
using DotNet_Training.Models.Domains;
using DotNet_Training.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly dasunDbcontext dbContext;

        public RegionsController(dasunDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        //get all regios
        //GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult Getall()
        {
            // get data from database - domain models
            var regionz = dbContext.Region.ToList();

            //map domain models to DTOs
            var regionzDto = new List<RegionDTO>();
            foreach (var region in regionz)
            {
                regionzDto.Add(new RegionDTO()
                {
                    Id= region.Id,
                    Code= region.Code,
                    Name= region.Name,
                    RegionImageUrl= region.RegionImageUrl,
                });
            }

            //return DTOs
            return Ok(regionzDto);
        }


        //get by ID
        //GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")] 
        public IActionResult Getbyid([FromRoute]Guid id)
        {
            //var regionz = dbContext.Region.Find(id);

            //GET region domain model from database
            var regionz = dbContext.Region.FirstOrDefault(x => x.Id == id);

            if(regionz == null)
            {
                return NotFound();
            }
            //map region domain model to region DTO
            var regionDto = new RegionDTO()
            {
                Id = regionz.Id,
                Code = regionz.Code,
                Name = regionz.Name,
                RegionImageUrl = regionz.RegionImageUrl
            };

            //return DTO back
            return Ok(regionDto);
        }


        //POST to create new region  
        //POST: https://localhost:portnumber/api/regions
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //map DTO to domain model
            var regionDomainModel = new Region()
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl,
            };

            //use domain model to create region
            dbContext.Region.Add(regionDomainModel);
            dbContext.SaveChanges();

            //map domain model back to DTO
            var regionDto = new RegionDTO()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return CreatedAtAction(nameof(Getbyid),new {id=regionDto.Id}, regionDto);
        }


        //Update region  
        //PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //check if region exists
            var regionDomainModel = dbContext.Region.FirstOrDefault(x => x.Id == id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            //map DTO to domain model
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl= updateRegionRequestDto.RegionImageUrl;

            dbContext.SaveChanges();

            //convert Domain Model to DTO
            var regndto = new RegionDTO()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return Ok(regndto);
        }
    }
}
