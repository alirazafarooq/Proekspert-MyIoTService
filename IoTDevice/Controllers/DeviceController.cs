using IoTDevice.Database;
using IoTDevice.Exceptions;
using IoTDevice.Models;
using IoTDevice.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IoTDevice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepository deviceRepository;

        public DeviceController(IoTDeviceDBContext dBContext)
        {
            deviceRepository = new DeviceRepository(dBContext);
        }

        /// <summary>
        /// This method is responsible to return all the IoT devices.
        /// </summary>
        /// <returns>Json object contains a list of IoT devices</returns>
        [HttpGet("getall")]
        public async Task<IActionResult> GetDevices()
        {
            var result = await deviceRepository.GetDevices();
            return new OkObjectResult(result);
        }

        /// <summary>
        /// This method is responsible to return an IoT device using Id as device serial number.
        /// </summary>
        /// <param name="id">Positive integer representing device serial number</param>
        /// <returns>Json object contains IoT device data</returns>
        [HttpGet]
        public async Task<IActionResult> GetDevice(int id)
        {
            var result = await deviceRepository.GetDevice(id);
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
        /// This method is responsible to generate an IoT device.
        /// </summary>
        /// <param name="device">Json Object contains the data about IoT device</param>
        /// <returns>Json object contains device data</returns>
        [HttpPost]
        public async Task<IActionResult> AddDevice(DeviceRequest device)
        {
            var result = await deviceRepository.AddDevice(device);
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
        /// This method is responsible to update the existing device data.
        /// </summary>
        /// <param name="device">Json Object contains the new data about IoT device</param>
        /// <returns>Json object contains updated device data</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateDevice(DeviceRequest device)
        {
            var result = await deviceRepository.UpdateDevice(device);
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
        /// This method is responsible to delete the existing device using Id.
        /// </summary>
        /// <param name="id">Positive integer representing device serial number</param>
        /// <returns>Json object contains updated device data</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteDevice(int id)
        {

            var result = await deviceRepository.DeleteDevice(id);
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
