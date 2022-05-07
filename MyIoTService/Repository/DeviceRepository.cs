using Microsoft.EntityFrameworkCore;
using MyIoTService.Database;
using MyIoTService.Entities;
using System.Threading.Tasks;

namespace MyIoTService.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IoTServiceDBContext _myDbContext;
        public DeviceRepository(IoTServiceDBContext myDBContext)
        {
            _myDbContext = myDBContext;
        }

        public async Task<Device> AddDevice(Device device)
        {
            _myDbContext.Add(device);
            await _myDbContext.SaveChangesAsync();
            return device;
        }

        public async Task DeleteDevice(int id)
        {
            var device = await _myDbContext.Devices.FindAsync(id);
            if (device != null)
            {
                _myDbContext.Devices.Remove(device);
                await _myDbContext.SaveChangesAsync();
            }
        }

        public Task<Device> FetchCurrentState(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Device> GetDevice(int id)
        {
            return await _myDbContext.Devices.FirstOrDefaultAsync(c => c.SerialNumber == id);
        }

        public async Task<Device> UpdateDevice(Device device)
        {
            if (device != null)
            {
                _myDbContext.Update(device);
                await _myDbContext.SaveChangesAsync();
            }
            return device;
        }
    }
}
