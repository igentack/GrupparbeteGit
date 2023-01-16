using System.ComponentModel.DataAnnotations;

namespace Gitgruppen.Models
{
    public class ReceiptModel
    {
        public Type Type { get; set; }

        [Key]
        public string LicensePlate { get; set; }

        public DateTime Arrived { get; set; }

        public DateTime Departured { get; set; }

        public TimeSpan ParkedTime { get; set; }

        public double ParkingCost { get; set; }

        public double HoursParked { get; set; }

        public string StrParkedTime { get; set; }
    }
}
