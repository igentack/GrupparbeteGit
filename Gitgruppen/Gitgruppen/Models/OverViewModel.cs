using System.ComponentModel.DataAnnotations;

namespace Gitgruppen.Models
{
    public class OverViewModel
    {
        public Type Type { get; set; }

        [Key]
        public string LicensePlate { get; set; }

        public string Brand { get; set; }

        public DateTime Arrived { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:ss}")]
        public TimeSpan ParkedTime { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public string Model { get; set; }

    }
}
