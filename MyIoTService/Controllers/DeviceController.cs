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

        /// <summary>
        /// This method is responsible to get all the devices of the respected user who is currently logged in.
        /// </summary>
        /// <returns>Json Object contains a list of registered devices</returns>
        [Authorize]
        [HttpGet("getall")]
        public async Task<IActionResult> GetDevices()
        {
            var contextUser = (UserModel)HttpContext.Items["EndUser"];
            var result = await deviceRepository.GetAllDevices(contextUser);
            return new OkObjectResult(result);
        }

        /// <summary>
        /// This method is resposible to fetch the current IoT device data and update this data into local database
        /// </summary>
        /// <param name="id">Integer value representing the device seriel number</param>
        /// <returns>Json Object contains the current device data</returns>
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

        /// <summary>
        /// Thid method is responsible to get the IoT device data stored in local database
        /// </summary>
        /// <param name="id">Integer value representing the device seriel number</param>
        /// <returns>Json Object contains the data of IoT device</returns>
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

        /// <summary>
        /// This method is reponsible to register a new device in database
        /// </summary>
        /// <param name="device">Json Object contains the data of IoT device</param>
        /// <returns>Json Object contains the data of IoT device</returns>
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

        /// <summary>
        /// This method is reponsible to update the device data both in local database as well as post the data to IoT device.
        /// </summary>
        /// <param name="device">Json Object contains the data of IoT device</param>
        /// <returns>Json Object contains the data of IoT device</returns>
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

        /// <summary>
        /// This method is responsible to delete the existing IoT device.
        /// </summary>
        /// <param name="id">Integer value representing the device seriel number</param>
        /// <returns>Json Object contains the data of IoT device</returns>
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
