using DotNet_Training.Context;
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
    }
}
