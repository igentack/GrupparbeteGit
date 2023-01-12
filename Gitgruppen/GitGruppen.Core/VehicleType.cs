using System.ComponentModel.DataAnnotations;
namespace GitGruppen.Core
{
    public class VehicleType
    {
        [Key]
        public int  Id { get; set; }

        public string Type { get; set; }
        public int NrOfSpaces { get; set; }
    }
}
