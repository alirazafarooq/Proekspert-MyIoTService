using Microsoft.AspNetCore.Mvc;
using MyIoTService.Exceptions.EndUsers;
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
            var result = await _endUserRepository.Authenticate(model);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return new BadRequestObjectResult(new UserCouldNotAuthenticateMessage());
            }
        }

        /// <summary>
        /// This endpoint is responsible to register the new user in MyIoTService.
        /// </summary>
        /// <returns>Json Object containing user object</returns>
        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            var result = await _endUserRepository.AddUser(model);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return new BadRequestObjectResult(new UserCouldNotRegisterMessage());
            }
        }

        /// <summary>
        /// This endpoint is responsible to update the existing user in MyIoTService.
        /// </summary>
        /// <returns>Json Object containing user object</returns>
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(UserModel model)
        {
            var result = await _endUserRepository.UpdateUser(model);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return new BadRequestObjectResult(new UserCouldNotUpdateMessage());
            }
        }

        /// <summary>
        /// This endpoint is responsible to delete the existing user in MyIoTService.
        /// </summary>
        /// <returns>Json Object containing user object</returns>
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _endUserRepository.DeleteUser(id);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return new BadRequestObjectResult(new UserCouldNotDeleteMessage());
            }
        }

        /// <summary>
        /// This endpoint is responsible to get the existing user in MyIoTService.
        /// </summary>
        /// <returns>Json Object containing user object</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _endUserRepository.GetUser(id);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return new BadRequestObjectResult(new UserNotFoundMessage());
            }
        }

        /// <summary>
        /// This endpoint is responsible to return all the users stored in the database
        /// </summary>
        /// <returns>A string object (Welcome message)</returns>
        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _endUserRepository.GetUsers();
            return new OkObjectResult(users);
        }
    }
}
