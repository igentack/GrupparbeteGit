using GitGruppen.Core;

namespace Gitgruppen.Models
{
    public class MemberDetailsView
    {
        public string PersNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
