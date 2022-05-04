using Microsoft.AspNetCore.Mvc;
using MyIoTService.Helpers;
using MyIoTService.Models;
using MyIoTService.Services;

namespace MyIoTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// This endpoint is responsible to authenticate the user based on Username and Password
        /// </summary>
        /// <returns>Json Object containing user object and respective token</returns>
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        /// <summary>
        /// This endpoint is responsible to return all the users stored in the database
        /// </summary>
        /// <returns>A string object (Welcome message)</returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
