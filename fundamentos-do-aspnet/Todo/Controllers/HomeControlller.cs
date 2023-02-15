using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers
{
    [ApiController]
    public class HomeControlller : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello world!";
        }
    }
}