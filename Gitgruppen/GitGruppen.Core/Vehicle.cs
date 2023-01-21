using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GitGruppen.Core
{
    public class Vehicle
    {
        [Key]
        [Required]
        [RegularExpression(@"(\w{3}-\d{3}|\w{3}\d{3}|\w{3} \d{3})$",
            ErrorMessage = "Not a proper Licence Plate")]
        public string LicensePlate { get; set; }

        [Display(Name = "Arrived Date")]
        public DateTime Arrived { get; set; } = DateTime.Now;

        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public int NumberOfWheels { get; set; }
        public int VehicleTypeId { get; set; }
    
        public VehicleType VehicleType { get; set; }

      

        public string MemberPersNr { get; set; }
        public Member Member { get; set; }

        public int? ParkingSpotId { get; set; }

        public ParkingSpot ParkingSpot { get; set; }  

        public Boolean isValid()
        {
            Regex regex = new Regex(@"(\w{3}-\d{3}|\w{3}\d{3}|\w{3} \d{3})");

            MatchCollection matches = regex.Matches(LicensePlate);

            if (matches.Count == 0)
            {
                return false;
            }

            return true;
        }
        public Boolean isValid(string licensePlate)
        {
            Regex regex = new Regex(@"(\w{3}-\d{3}|\w{3}\d{3}|\w{3} \d{3})");

            MatchCollection matches = regex.Matches(licensePlate);

            if (matches.Count == 0)
            {
                return false;
            }

            return true;
        }


    }
}
