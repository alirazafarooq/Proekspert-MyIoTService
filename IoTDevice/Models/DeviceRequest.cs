using IoTDevice.Entities;
using System;

namespace IoTDevice.Models
{
    public class DeviceRequest
    {
        public int SerialNumber { get; set; }

        public bool HasOutsideTemperature { get; set; }

        public bool IsOperational { get; set; }

        public bool SilentMode { get; set; }

        public bool MachineIsBroken { get; set; }

        public Device DeviceEntity()
        {
            return new Device()
            {
                SerialNumber = SerialNumber,
                HasOutsideTemperature = HasOutsideTemperature,
                IsOperational = IsOperational,
                MachineIsBroken = MachineIsBroken,
                SilentMode = SilentMode,
                DeviceStartTime = DateTime.UtcNow
            };
        }
    }
}
