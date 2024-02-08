using DotNet_Training.Context;
using DotNet_Training.Models.Domains;
using DotNet_Training.Models.DTO;
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

        public RegionsController(dasunDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        //get all regios
        //GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            // get data from database - domain models
            var regionz = await dbContext.Region.ToListAsync();

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
        public async Task<IActionResult> Getbyid([FromRoute]Guid id)
        {
            //var regionz = dbContext.Region.Find(id);

            //GET region domain model from database
            var regionz = await dbContext.Region.FirstOrDefaultAsync(x => x.Id == id);

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
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //map DTO to domain model
            var regionDomainModel = new Region() //methana region walinma karanna ona api dbcontext eke kiyala thiyenawane database ekata api danne region type eke oblect kiyala
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl,
            };

            //use domain model to create region
            await dbContext.Region.AddAsync(regionDomainModel);
            await dbContext.SaveChangesAsync();

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
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //check if region exists
            var regionDomainModel = await dbContext.Region.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            //map DTO to domain model
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl= updateRegionRequestDto.RegionImageUrl;

            await dbContext.SaveChangesAsync();

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

        //Delete region  
        //DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await dbContext.Region.FirstOrDefaultAsync(x => x.Id == id);
            if(regionDomainModel == null)
            {
                return NotFound();
            }

            //Delete region
            dbContext.Region.Remove(regionDomainModel); // remove is not having a async method
            await dbContext.SaveChangesAsync();

            //if needed , return deleted region 
            //map domain model to dto
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
