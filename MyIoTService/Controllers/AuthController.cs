using Microsoft.AspNetCore.Mvc;
using MyIoTService.Entities;
using MyIoTService.Helpers;
using MyIoTService.Models;
using MyIoTService.Repository;
using System.Threading.Tasks;

namespace MyIoTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IEndUserRepository _endUserRepository;

        public AuthController(IEndUserRepository endUserRepository)
        {
            _endUserRepository = endUserRepository;
        }

        /// <summary>
        /// This endpoint is responsible to authenticate the user based on Username and Password
        /// </summary>
        /// <returns>Json Object containing user object and respective token</returns>
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _endUserRepository.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        /// <summary>
        /// This endpoint is responsible to register the new user in MyIoTService.
        /// </summary>
        /// <returns>Json Object containing user object</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest model)
        {
            if (model != null)
            {
                var entity = new EndUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password = model.Password,
                    Username = model.Username,
                };
                var response = await _endUserRepository.AddUser(entity);
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// This endpoint is responsible to return all the users stored in the database
        /// </summary>
        /// <returns>A string object (Welcome message)</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _endUserRepository.GetUsers();
            return Ok(users);
        }
    }
}
