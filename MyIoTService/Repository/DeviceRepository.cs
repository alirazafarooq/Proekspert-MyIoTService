using Microsoft.EntityFrameworkCore;
using MyIoTService.Database;
using MyIoTService.Entities;
using MyIoTService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MyIoTService.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IoTServiceDBContext ioTServiceDbContext;
        public DeviceRepository(IoTServiceDBContext dBContext)
        {
            ioTServiceDbContext = dBContext;
        }

        public async Task<DeviceRegisterResponse> AddDevice(DeviceRegisterRequest device, EndUser endUser)
        {
            try
            {
                //Implement Device Integration Service Response
                var response = new DeviceRegisterResponse();
                //---------------------------------------------

                var result = await ioTServiceDbContext.Devices.AddAsync(response.DeviceEntity(endUser));
                await ioTServiceDbContext.SaveChangesAsync();
                return new DeviceRegisterResponse(result.Entity);

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<DeviceRegisterResponse> DeleteDevice(int id, EndUser endUser)
        {
            var device = await ioTServiceDbContext.Devices.FindAsync(id);
            if (device != null)
            {
                try
                {
                    //Implement Device Integration Service Response
                    var response = new DeviceRegisterResponse();
                    //---------------------------------------------

                    var result = ioTServiceDbContext.Devices.Remove(device);
                    await ioTServiceDbContext.SaveChangesAsync();
                    return new DeviceRegisterResponse(result.Entity);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else return null;
        }

        public async Task<DeviceRegisterResponse> FetchCurrentState(int id, EndUser endUser)
        {
            //Implement Device Integration Service Response
            var response = new DeviceRegisterResponse();
            //---------------------------------------------

            var result = ioTServiceDbContext.Devices.Update(response.DeviceEntity(endUser));
            await ioTServiceDbContext.SaveChangesAsync();
            return new DeviceRegisterResponse(result.Entity);
        }

        public async Task<IEnumerable<DeviceRegisterResponse>> GetAllDevices(EndUser endUser)
        {
            return await ioTServiceDbContext.Devices.Where(d => d.UserId == endUser.Id).Select(d => new DeviceRegisterResponse(d)).ToListAsync();
        }

        public async Task<DeviceRegisterResponse> GetDevice(int id, EndUser endUser)
        {
            var result = await ioTServiceDbContext.Devices.FindAsync(id);
            if (result != null)
            {
                if (result.UserId == endUser.Id)
                {
                    return new DeviceRegisterResponse(result);
                }
                else
                {
                    return null;
                }
            }
            else return null;
        }

        public async Task<DeviceRegisterResponse> UpdateDevice(DeviceRegisterRequest device, EndUser endUser)
        {

            try
            {
                var deviceResult = await ioTServiceDbContext.Devices.FindAsync(device.SerialNumber);
                if (deviceResult.UserId == endUser.Id)
                {
                    //Implement Device Integration Service Response
                    var response = new DeviceRegisterResponse();
                    //---------------------------------------------

                    var result = ioTServiceDbContext.Devices.Update(response.DeviceEntity(endUser));
                    await ioTServiceDbContext.SaveChangesAsync();
                    return new DeviceRegisterResponse(result.Entity);
                }
                else return null;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
