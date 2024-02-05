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


        [HttpGet]
        public IActionResult Getall()
        {
            var regionz = dbContext.Region.ToList();
            return Ok(regionz);
        }
    }
}
