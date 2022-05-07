using IoTDevice.Entities;
using System;

namespace IoTDevice.Models
{
    public class DeviceResponse
    {
        public int SerialNumber { get; set; }

        public int InsideTemperature { get; set; }

        public int OutsideTemperature { get; set; }

        public bool HasOutsideTemperature { get; set; }

        public int WaterTemperature { get; set; }

        public int OperationTimeInSec { get; set; }

        public int OperationTimeInHour { get; set; }

        public bool IsOperational { get; set; }

        public bool SilentMode { get; set; }

        public bool MachineIsBroken { get; set; }

        public DeviceResponse DeviceModelFrom(Device device)
        {
            var fakeData = DeviceFakeData.FakeData.Generate();
            return new DeviceResponse()
            {
                SerialNumber = device.SerialNumber,
                HasOutsideTemperature = device.HasOutsideTemperature,
                IsOperational = device.IsOperational,
                MachineIsBroken = device.MachineIsBroken,
                OperationTimeInHour = Convert.ToInt32(DateTime.UtcNow.Subtract(device.DeviceStartTime).TotalHours),
                OperationTimeInSec = Convert.ToInt32(DateTime.UtcNow.Subtract(device.DeviceStartTime).TotalSeconds),
                SilentMode = device.SilentMode,
                InsideTemperature = fakeData.InsideTemperature,
                OutsideTemperature = fakeData.OutsideTemperature,
                WaterTemperature = fakeData.WaterTemperature
            };
        }
    }
}
