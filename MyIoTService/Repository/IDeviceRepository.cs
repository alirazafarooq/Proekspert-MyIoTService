using MyIoTService.Entities;
using MyIoTService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyIoTService.Repository
{
    public interface IDeviceRepository
    {
        Task<DeviceRegisterResponse> GetDevice(int id, UserModel endUser);
        Task<IEnumerable<DeviceRegisterResponse>> GetAllDevices(UserModel endUser);
        Task<DeviceRegisterResponse> AddDevice(DeviceRegisterRequest device, UserModel endUser);
        Task<DeviceRegisterResponse> UpdateDevice(DeviceRegisterRequest device, UserModel endUser);
        Task<DeviceRegisterResponse> DeleteDevice(int id, UserModel endUser);
        Task<DeviceRegisterResponse> FetchCurrentState(int id, UserModel endUser);
    }
}
