namespace MyIoTService.Models
{
    public class DeviceRegisterRequest
    {
        public int SerialNumber { get; set; }

        public bool HasOutsideTemperature { get; set; }

        public bool IsOperational { get; set; }

        public bool SilentMode { get; set; }

        public bool MachineIsBroken { get; set; }
    }
}
