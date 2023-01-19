using GitGruppen.Core;

namespace Gitgruppen.Models
{
    public class CheckoutView
    {
        public string MemberPersNr { get; internal set; }
        public DateTime Arrived { get; set; }
        public string LicensePlate { get; set; }
        
    }
}
