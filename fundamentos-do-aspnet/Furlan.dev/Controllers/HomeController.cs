using Microsoft.AspNetCore.Mvc;

namespace Furlan.dev.Controllers
{
    [Controller]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("health-check")]
        public IActionResult Get()
            => Ok(new { online = "true" });
    }
}