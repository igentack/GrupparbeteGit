using GitGruppen.Core;

namespace Gitgruppen.Models
{
    public class CheckinView
    {
        public string licenseplate { get; set; }
        public int Id { get; set; }

        public List<ParkingSpot> FreeParkingSpots { get; set; }
    }
}
