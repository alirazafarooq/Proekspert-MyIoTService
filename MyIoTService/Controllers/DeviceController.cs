using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyIoTService.Entities;
using MyIoTService.Repository;

namespace MyIoTService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private IDeviceRepository _deviceRepository;
        private readonly EndUser contextUser;
        public DeviceController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
            contextUser = (EndUser)HttpContext.Items["EndUser"];
        }
    }
}
