using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace GitGruppen.Core
{
    public class Member
    {
        [Key]
        [Required]
        [RegularExpression(@"^(\d{10}|\d{12}|\d{6}-\d{4}|\d{8}-\d{4}|\d{8} \d{4}|\d{6} \d{4})$",
            ErrorMessage = "Not a proper Personnummer")]
        public string PersNr { get; set; }
        [Required]
        //[NameNotTheSame("LastName", ErrorMessage = "{0} cannot be the same as {1}")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";  
        
       /* public Membership Membership { get; set; }*/

        public ICollection<Vehicle>? Vehicles { get; set; }

      /*  public ICollection<Receipt> Receipts { get; set; }*/

        public Boolean isValid()
        {
            Regex regex = new Regex(@"^(\d{10}|\d{12}|\d{6}-\d{4}|\d{8}-\d{4}|\d{8} \d{4}|\d{6} \d{4})$");

            MatchCollection matches = regex.Matches(PersNr);

            if (matches.Count == 0)
            {
                return false;
            }
            if (FirstName == LastName)
            {
                return false;
            }

            return true;
        }
        public Boolean isValid(string pnr, string firstName, string lastName)
        {
            Regex regex = new Regex(@"^(\d{10}|\d{12}|\d{6}-\d{4}|\d{8}-\d{4}|\d{8} \d{4}|\d{6} \d{4})");

            MatchCollection matches = regex.Matches(pnr);

            if (matches.Count == 0)
            {
                return false;
            }
            if (firstName == lastName)
            {
                return false;
            }

            return true;
        }
    }
    //public class NameNotTheSame : ValidationAttribute
    //{
    //    private readonly string _lastName;

    //    public NameNotTheSame(string lastName)
    //    {
    //        _lastName = lastName;
    //    }

    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        ErrorMessage = ErrorMessageString;
    //        var currentValue = (string)value;

    //        var property = validationContext.ObjectType.GetProperty(_lastName);

    //        if (property == null)
    //            throw new ArgumentException("Property with this name not found");

    //        var comparisonValue = (string)property.GetValue(validationContext.ObjectInstance); 

    //        if (currentValue.Equals(comparisonValue))
    //            return new ValidationResult(ErrorMessage);

    //        return ValidationResult.Success;
    //    }
    //}
  /*  public enum Membership
    {
        Member,
        Gold,
        Pro,
    }*/
}
