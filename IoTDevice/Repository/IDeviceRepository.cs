using IoTDevice.Entities;
using IoTDevice.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTDevice.Repository
{
    public interface IDeviceRepository
    {
        Task<DeviceResponse> AddDevice(DeviceRequest device);

        Task<DeviceResponse> UpdateDevice(DeviceRequest device);

        Task<DeviceResponse> DeleteDevice(int id);

        Task<IEnumerable<DeviceResponse>> GetDevices();

        Task<DeviceResponse> GetDevice(int id);
    }
}
