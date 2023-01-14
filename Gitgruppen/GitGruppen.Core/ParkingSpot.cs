using System.ComponentModel.DataAnnotations;
namespace GitGruppen.Core
{
#nullable disable
    public class ParkingSpot
    {
        public int Id { get; set; }
        
        public DateTime TimeArrival { get;}

        public string SpotName { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
    