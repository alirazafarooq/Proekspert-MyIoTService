using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyIoTService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// The landing endpoint for the MyIoTService
        /// </summary>
        /// <returns>A string object (Welcome message)</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return new OkObjectResult("Welcome");
        }
    }
}
