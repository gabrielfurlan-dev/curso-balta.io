using Furlan.dev.Services;
using Microsoft.AspNetCore.Mvc;

namespace Furlan.dev.Controllers
{

    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("v1/login")]
        public IActionResult Login(
            [FromServices] TokenService tokenService
        )
        {
            var token = tokenService.GenerateToken(null);
            
            return Ok(token);
        }

    }
} 