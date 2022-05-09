using MyIoTService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyIoTService.Services
{
    public interface IDeviceIntegrationService
    {
        Task<DeviceRegisterResponse> GetDevice(int id);
        Task<IEnumerable<DeviceRegisterResponse>> GetAllDevices();
        Task<DeviceRegisterResponse> AddDevice(DeviceRegisterRequest device);
        Task<DeviceRegisterResponse> UpdateDevice(DeviceRegisterRequest device);
        Task<DeviceRegisterResponse> DeleteDevice(int id);
    }
}
