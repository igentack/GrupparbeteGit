using GitGruppen.Core;
using System.ComponentModel.DataAnnotations;

namespace Gitgruppen.Models
{
    public class OverViewModel
    {
        public Member Member { get; set; }

        public int MemberHasNrVehicles { get; set; }

        public String Type { get; set; }
        
        [Key]
        public string? LicensePlate { get; set; }
        
        public string? Brand { get; set; }
        
        public string VehicleTypeType { get; set; }
        public DateTime Arrived { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:ss}")]
        public DateTime ParkedTime { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public string Model { get; set; }

    }
}
