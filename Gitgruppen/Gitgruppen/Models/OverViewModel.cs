using System.ComponentModel.DataAnnotations;

namespace Gitgruppen.Models
{
    public class OverViewModel
    {
        public Type Type { get; set; }
        
        public string LicensePlate { get; set; }
        
        public string Brand { get; set; }
        
        public DateTime Arrived { get; set; }

        public TimeSpan ParkedTime { get; set; }    

    }
}
