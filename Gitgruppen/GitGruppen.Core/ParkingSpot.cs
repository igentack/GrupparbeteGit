using System.ComponentModel.DataAnnotations;
namespace GitGruppen.Core
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public DateTime TimeArrival { get;}

        public string SpotName { get; set; }

        public string VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
    