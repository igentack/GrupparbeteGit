using Bogus.DataSets;
using GitGruppen.Core;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Gitgruppen.Models
{
    public class VehicleView
    {
        public string LicensePlate { get; set; }

        [Display(Name = "Arrived Date")]
        public DateTime Arrived { get; set; }

        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public int NumberOfWheels { get; set; }
        public int TypeId { get; set; }
        public string VehicleTypeName { get; set; }
        public VehicleType VehicleType { get; set; }
        public string MemberId { get; set; }
        public string FullName { get; set; }
        public int? ParkingSpotId { get; set; }
        public List<VehicleType> VehicleTypes { get; internal set; }
    }
}
