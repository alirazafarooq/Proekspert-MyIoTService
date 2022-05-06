using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyIoTService.Entities
{
    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [ForeignKey("UserId")]
        public EndUser EndUser { get; set; }
        public int UserId { get; set; }
    }
}
