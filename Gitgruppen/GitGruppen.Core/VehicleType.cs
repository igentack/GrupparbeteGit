using System.ComponentModel.DataAnnotations;
namespace GitGruppen.Core
{
#nullable disable
    public class VehicleType
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public int NrOfSpaces { get; set; }
    }
}
