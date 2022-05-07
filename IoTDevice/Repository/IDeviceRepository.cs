using IoTDevice.Entities;
using IoTDevice.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTDevice.Repository
{
    public interface IDeviceRepository
    {
        Task AddDevice(DeviceRequest device);

        Task UpdateDevice(DeviceRequest device);

        Task DeleteDevice(int id);

        Task<IEnumerable<DeviceResponse>> GetDevices();

        Task<DeviceResponse> GetDevice(int id);
    }
}
