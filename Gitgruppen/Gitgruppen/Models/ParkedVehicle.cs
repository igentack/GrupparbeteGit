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


        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)] <= fick ej denna att fungera
        public DateTime Arrived { get; private set; } = DateTime.Now;

        // TODO Kanske implementera en [Not Mapped] prop som räknar ut parkeringstiden?

        // TODO Enligt bonusuppgiften "Parkeradtid". 



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
