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
    }
}
