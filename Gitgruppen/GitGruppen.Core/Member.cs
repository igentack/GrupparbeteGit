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
        
       /* public Membership Membership { get; set; }*/

        public ICollection<Vehicle> Vehicles { get; set; }

      /*  public ICollection<Receipt> Receipts { get; set; }*/

        public Boolean isValid(string pnr)
        {
            Regex regex = new Regex(@"^(\d{10}|\d{12}|\d{6}-\d{4}|\d{8}-\d{4}|\d{8} \d{4}|\d{6} \d{4})");

            MatchCollection matches = regex.Matches(pnr);

            if (matches.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
  /*  public enum Membership
    {
        Member,
        Gold,
        Pro,
    }*/
}
