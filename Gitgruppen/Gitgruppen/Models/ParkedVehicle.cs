using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gitgruppen.Models
{
    public class ParkedVehicle
    {
        [Key]
        public string LicensePlate { get; set; }
        public Type Type { get; set; }

        public DateTime Arrived { get; set; } = DateTime.Now;

        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public int NumberOfWheels { get; set; }


    }
    public enum Type
    {
        Car,
        MotorCycle,
        Boat,
        BiCycle,
    }
}
