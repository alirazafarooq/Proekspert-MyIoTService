using IoTDevice.Database;
using IoTDevice.Entities;
using IoTDevice.Repository;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetDevices()
        {
            var result = await deviceRepository.GetDevices();
            return new OkObjectResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetDevice(int id)
        {
            var result = await deviceRepository.GetDevice(id);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDevice(Device device)
        {
            await deviceRepository.AddDevice(device);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDevice(Device device)
        {
            await deviceRepository.UpdateDevice(device);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            await deviceRepository.DeleteDevice(id);
            return Ok();
        }
    }
}
