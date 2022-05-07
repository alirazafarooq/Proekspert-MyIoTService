using MyIoTService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyIoTService.Repository
{
    public interface IDeviceRepository
    {
        Task<Device> GetDevice(int id);
        Task<Device> AddDevice(Device device);
        Task<Device> UpdateDevice(Device device);
        Task DeleteDevice(int id);
        Task<Device> FetchCurrentState(int id);
    }
}
