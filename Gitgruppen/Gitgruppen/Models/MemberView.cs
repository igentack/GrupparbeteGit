using GitGruppen.Core;

namespace Gitgruppen.Models
{
    public class MemberView
    {
        public string PersNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int MemberHasNrVehicles { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
