using System.ComponentModel.DataAnnotations;

namespace GitGruppen.Core
{
#nullable disable
    public class Vehicle
    {
        [Key]
        public string LicensePlate { get; set; } 

        [Display(Name = "Arrived Date")]
        public DateTime Arrived { get; set; }

        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public int NumberOfWheels { get; set; }
        public VehicleType VehicleType { get; set; }
        public Member Member { get; set;}



    }
}
