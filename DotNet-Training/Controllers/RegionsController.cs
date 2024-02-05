using DotNet_Training.Context;
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
            var regionz = dbContext.Region.ToList();
            return Ok(regionz);
        }

        //get by ID
        //GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")] 
        public IActionResult Getbyid([FromRoute]Guid id)
        {
            var regionz = dbContext.Region.Find(id);
            if(regionz == null)
            {
                return NotFound();
            }
            return Ok(regionz);
        }
    }
}
