using IoTDevice.Database;
using IoTDevice.Entities;
using IoTDevice.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace IoTDevice.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IoTDeviceDBContext ioTDeviceDBContext;
        public DeviceRepository(IoTDeviceDBContext dBContext)
        {
            ioTDeviceDBContext = dBContext;
        }

        public async Task AddDevice(Device device)
        {
            if (device != null)
            {
                await ioTDeviceDBContext.devices.AddAsync(device);
                await ioTDeviceDBContext.SaveChangesAsync();
            }
        }

        public async Task DeleteDevice(int id)
        {
            var device = await ioTDeviceDBContext.devices.FindAsync(id);
            if (device != null)
            {
                ioTDeviceDBContext.devices.Remove(device);
                await ioTDeviceDBContext.SaveChangesAsync();
            }
        }

        public async Task<DeviceModel> GetDevice(int id)
        {
            var device = await ioTDeviceDBContext.devices.FindAsync(id);
            if (device != null)
            {
                return new DeviceModel().DeviceModelFrom(device);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<DeviceModel>> GetDevices()
        {
            var devices = await ioTDeviceDBContext.devices.ToListAsync();
            return devices.Select(d => new DeviceModel().DeviceModelFrom(d));
        }

        public async Task UpdateDevice(Device device)
        {
            ioTDeviceDBContext.Update(device);
            await ioTDeviceDBContext.SaveChangesAsync();
        }
    }
}
