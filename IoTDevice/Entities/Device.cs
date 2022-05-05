using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoTDevice.Entities
{
    [Table("Device")]
    public class Device
    {
        [Key]
        [Required]
        public int SerialNumber { get; set; }

        public bool HasOutsideTemperature { get; set; }

        public int OperationTimeInSec { get; set; }

        public int OperationTimeInHour { get; set; }

        public bool IsOperational { get; set; }

        public bool SilentMode { get; set; }

        public bool MachineIsBroken { get; set; }

    }
}
