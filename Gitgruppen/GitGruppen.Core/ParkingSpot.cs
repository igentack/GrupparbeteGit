using System.ComponentModel.DataAnnotations;
namespace GitGruppen.Core
{
    public class ParkingSpot
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeArrival { get;}

        public string SpotName { get; set; }

        public Vehicle? vehicle { get; set; }
    }
}
    