using Microsoft.AspNetCore.Mvc;

namespace TechnicalTest.Identity.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(true);
        }
    }
}
