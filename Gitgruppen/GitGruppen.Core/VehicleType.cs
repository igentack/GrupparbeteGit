using System.ComponentModel.DataAnnotations;
namespace GitGruppen.Core
{
    public class VehicleType
    {

        public int Id { get; set; }

        public string? Type { get; set; }
        public int NrOfSpaces { get; set; }

        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}
