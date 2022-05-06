namespace MyIoTService.Models
{
    public class DeviceRegisterRequest
    {
        public bool HasOutsideTemperature { get; set; }

        public int OperationTimeInSec { get; set; }

        public int OperationTimeInHour { get; set; }

        public bool IsOperational { get; set; }

        public bool SilentMode { get; set; }

        public bool MachineIsBroken { get; set; }

        public int UserId { get; set; }
    }
}
