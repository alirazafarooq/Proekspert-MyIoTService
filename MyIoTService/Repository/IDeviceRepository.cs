using MyIoTService.Entities;
using MyIoTService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyIoTService.Repository
{
    public interface IDeviceRepository
    {
        Task<DeviceRegisterResponse> GetDevice(int id, EndUser endUser);
        Task<IEnumerable<DeviceRegisterResponse>> GetAllDevices(EndUser endUser);
        Task<DeviceRegisterResponse> AddDevice(DeviceRegisterRequest device, EndUser endUser);
        Task<DeviceRegisterResponse> UpdateDevice(DeviceRegisterRequest device, EndUser endUser);
        Task<DeviceRegisterResponse> DeleteDevice(int id, EndUser endUser);
        Task<DeviceRegisterResponse> FetchCurrentState(int id, EndUser endUser);
    }
}
