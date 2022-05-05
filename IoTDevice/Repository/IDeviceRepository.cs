using IoTDevice.Entities;
using IoTDevice.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTDevice.Repository
{
    public interface IDeviceRepository
    {
        Task AddDevice(Device device);

        Task UpdateDevice(Device device);

        Task DeleteDevice(int id);

        Task<IEnumerable<DeviceModel>> GetDevices();

        Task<DeviceModel> GetDevice(int id);
    }
}
