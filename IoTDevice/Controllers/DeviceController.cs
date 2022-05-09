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

        [HttpGet("getall")]
        public async Task<IActionResult> GetDevices()
        {
            var result = await deviceRepository.GetDevices();
            return new OkObjectResult(result);
        }

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
