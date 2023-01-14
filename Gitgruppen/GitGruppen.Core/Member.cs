using System.ComponentModel.DataAnnotations;
namespace GitGruppen.Core
{
    public class Member
    {
        [Key]
        public string PersNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Vehicle> Vehicles { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
