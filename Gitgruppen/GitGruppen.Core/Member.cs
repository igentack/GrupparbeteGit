using System.ComponentModel.DataAnnotations;
namespace GitGruppen.Core
{
#nullable disable
    public class Member
    {
        [Key]
        public string PersNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public int Age { get; set; }

        public MemberShip MemberShip { get; set; }  

        public ICollection<Vehicle> Vehicles { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }

    public enum MemberShip
    {
        Member,
        Gold,
        Pro,    
    }
}
