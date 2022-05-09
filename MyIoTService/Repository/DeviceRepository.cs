using Microsoft.EntityFrameworkCore;
using MyIoTService.Database;
using MyIoTService.Entities;
using MyIoTService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MyIoTService.Services;

namespace MyIoTService.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IoTServiceDBContext ioTServiceDbContext;
        private readonly IDeviceIntegrationService deviceIntegrationService;
        public DeviceRepository(IoTServiceDBContext dBContext, IDeviceIntegrationService integrationService)
        {
            ioTServiceDbContext = dBContext;
            deviceIntegrationService = integrationService;
        }

        public async Task<DeviceRegisterResponse> AddDevice(DeviceRegisterRequest device, UserModel endUser)
        {
            try
            {
                // Integration Service
                var response = await deviceIntegrationService.AddDevice(device);
                if (response == null) return null;

                var result = await ioTServiceDbContext.Devices.AddAsync(response.DeviceEntity(endUser));
                await ioTServiceDbContext.SaveChangesAsync();
                return new DeviceRegisterResponse(result.Entity);

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<DeviceRegisterResponse> DeleteDevice(int id, UserModel endUser)
        {
            var device = await ioTServiceDbContext.Devices.FindAsync(id);
            if (device != null)
            {
                try
                {
                    // Integration Service
                    var response = await deviceIntegrationService.DeleteDevice(id);
                    if (response == null) return null;

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

        public async Task<DeviceRegisterResponse> FetchCurrentState(int id, UserModel endUser)
        {
            var deviceResult = await ioTServiceDbContext.Devices.FindAsync(id);
            if (deviceResult.UserId == endUser.Id)
            {
                // Integration Service
                var response = await deviceIntegrationService.GetDevice(id);
                if (response == null) return null;

                // Update Feilds
                deviceResult.HasOutsideTemperature = response.HasOutsideTemperature;
                deviceResult.OutsideTemperature = response.OutsideTemperature;
                deviceResult.InsideTemperature = response.InsideTemperature;
                deviceResult.OperationTimeInHour = response.OperationTimeInHour;
                deviceResult.OperationTimeInSec = response.OperationTimeInSec;
                deviceResult.IsOperational = response.IsOperational;
                deviceResult.MachineIsBroken = response.MachineIsBroken;
                deviceResult.SilentMode = response.SilentMode;
                deviceResult.WaterTemperature = response.WaterTemperature;

                var result = ioTServiceDbContext.Devices.Update(deviceResult);
                await ioTServiceDbContext.SaveChangesAsync();
                return new DeviceRegisterResponse(result.Entity);
            }
            else return null;
        }

        public async Task<IEnumerable<DeviceRegisterResponse>> GetAllDevices(UserModel endUser)
        {
            return await ioTServiceDbContext.Devices.Where(d => d.UserId == endUser.Id).Select(d => new DeviceRegisterResponse(d)).ToListAsync();
        }

        public async Task<DeviceRegisterResponse> GetDevice(int id, UserModel endUser)
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

        public async Task<DeviceRegisterResponse> UpdateDevice(DeviceRegisterRequest device, UserModel endUser)
        {

            try
            {
                var deviceResult = await ioTServiceDbContext.Devices.FindAsync(device.SerialNumber);
                if (deviceResult.UserId == endUser.Id)
                {
                    // Integration Service
                    var response = await deviceIntegrationService.UpdateDevice(device);
                    if (response == null) return null;

                    // Update Feilds
                    deviceResult.HasOutsideTemperature = response.HasOutsideTemperature;
                    deviceResult.OutsideTemperature = response.OutsideTemperature;
                    deviceResult.InsideTemperature = response.InsideTemperature;
                    deviceResult.OperationTimeInHour = response.OperationTimeInHour;
                    deviceResult.OperationTimeInSec = response.OperationTimeInSec;
                    deviceResult.IsOperational = response.IsOperational;
                    deviceResult.MachineIsBroken = response.MachineIsBroken;
                    deviceResult.SilentMode = response.SilentMode;
                    deviceResult.WaterTemperature = response.WaterTemperature;

                    var result = ioTServiceDbContext.Devices.Update(deviceResult);
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
