using MyIoTService.Entities;

namespace MyIoTService.Models
{
    public class DeviceRegisterResponse
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

        public DeviceRegisterResponse() { }
        public DeviceRegisterResponse(Device device)
        {
            SerialNumber = device.SerialNumber;
            InsideTemperature = device.InsideTemperature;
            OutsideTemperature = device.OutsideTemperature;
            HasOutsideTemperature = device.HasOutsideTemperature;
            WaterTemperature = device.WaterTemperature;
            OperationTimeInSec = device.OperationTimeInSec;
            OperationTimeInHour = device.OperationTimeInHour;
            IsOperational = device.IsOperational;
            SilentMode = device.SilentMode;
            MachineIsBroken = device.MachineIsBroken;
        }
        public Device DeviceEntity(UserModel endUser)
        {
            return new Device()
            {
                UserId = endUser.Id,
                HasOutsideTemperature = HasOutsideTemperature,
                InsideTemperature = InsideTemperature,
                IsOperational = IsOperational,
                MachineIsBroken = MachineIsBroken,
                OperationTimeInHour = OperationTimeInHour,
                OperationTimeInSec = OperationTimeInSec,
                OutsideTemperature = OutsideTemperature,
                SerialNumber = SerialNumber,
                SilentMode = SilentMode,
                WaterTemperature = WaterTemperature
            };
        }
    }
}
