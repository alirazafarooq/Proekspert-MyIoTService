using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyIoTService.Entities;
using MyIoTService.Exceptions.Device;
using MyIoTService.Helpers;
using MyIoTService.Models;
using MyIoTService.Repository;
using System.Threading.Tasks;

namespace MyIoTService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private IDeviceRepository deviceRepository;
        public DeviceController(IDeviceRepository deviceRepository)
        {
            this.deviceRepository = deviceRepository;
        }

        [Authorize]
        [HttpGet("getall")]
        public async Task<IActionResult> GetDevices()
        {
            var contextUser = (UserModel)HttpContext.Items["EndUser"];
            var result = await deviceRepository.GetAllDevices(contextUser);
            return new OkObjectResult(result);
        }

        [Authorize]
        [HttpGet("fetchcurrentstate")]
        public async Task<IActionResult> FetchCurrentState(int id)
        {
            var contextUser = (UserModel)HttpContext.Items["EndUser"];
            var result = await deviceRepository.FetchCurrentState(id, contextUser);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return new BadRequestObjectResult(new DeviceNotFoundMessage());
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetDevice(int id)
        {
            var contextUser = (UserModel)HttpContext.Items["EndUser"];
            var result = await deviceRepository.GetDevice(id, contextUser);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return new BadRequestObjectResult(new DeviceNotFoundMessage());
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddDevice(DeviceRegisterRequest device)
        {
            var contextUser = (UserModel)HttpContext.Items["EndUser"];
            var result = await deviceRepository.AddDevice(device, contextUser);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return new BadRequestObjectResult(new DeviceCouldNotRegisterMessage());
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateDevice(DeviceRegisterRequest device)
        {
            var contextUser = (UserModel)HttpContext.Items["EndUser"];
            var result = await deviceRepository.UpdateDevice(device, contextUser);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return new BadRequestObjectResult(new DeviceCouldNotUpdateMessage());
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var contextUser = (UserModel)HttpContext.Items["EndUser"];
            var result = await deviceRepository.DeleteDevice(id, contextUser);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return new BadRequestObjectResult(new DeviceCouldNotDeleteMessage());
            }
        }
    }
}
