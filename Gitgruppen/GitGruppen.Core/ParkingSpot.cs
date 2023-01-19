using System.ComponentModel.DataAnnotations;
namespace GitGruppen.Core
{
    public class ParkingSpot
    {

        public int Id { get; set; }
        public DateTime TimeArrival { get; }

        public int SpotNo { get; set; }

        public Vehicle? Vehicle { get; set; }
         
    }
}
    