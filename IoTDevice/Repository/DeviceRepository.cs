using IoTDevice.Database;
using IoTDevice.Entities;
using IoTDevice.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace IoTDevice.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IoTDeviceDBContext ioTDeviceDBContext;
        public DeviceRepository(IoTDeviceDBContext dBContext)
        {
            ioTDeviceDBContext = dBContext;
        }

        public async Task<DeviceResponse> AddDevice(DeviceRequest device)
        {
            try
            {
                var result = await ioTDeviceDBContext.devices.AddAsync(device.DeviceEntity());
                await ioTDeviceDBContext.SaveChangesAsync();
                return new DeviceResponse().DeviceModelFrom(result.Entity);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<DeviceResponse> DeleteDevice(int id)
        {
            var device = await ioTDeviceDBContext.devices.FindAsync(id);
            if (device != null)
            {
                try
                {
                    var result = ioTDeviceDBContext.devices.Remove(device);
                    await ioTDeviceDBContext.SaveChangesAsync();
                    return new DeviceResponse().DeviceModelFrom(result.Entity);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<DeviceResponse> GetDevice(int id)
        {
            var device = await ioTDeviceDBContext.devices.FindAsync(id);
            if (device != null)
            {
                return new DeviceResponse().DeviceModelFrom(device);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<DeviceResponse>> GetDevices()
        {
            var devices = await ioTDeviceDBContext.devices.ToListAsync();
            return devices.Select(d => new DeviceResponse().DeviceModelFrom(d));
        }

        public async Task<DeviceResponse> UpdateDevice(DeviceRequest device)
        {
            try
            {
                var result = ioTDeviceDBContext.Update(device.DeviceEntity());
                await ioTDeviceDBContext.SaveChangesAsync();
                return new DeviceResponse().DeviceModelFrom(result.Entity);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
