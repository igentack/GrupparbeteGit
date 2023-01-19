using System.ComponentModel.DataAnnotations;
using GitGruppen.Core;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gitgruppen.Models
{
    public class MemberView
    {
        [Required]
        [RegularExpression(@"^(\d{10}|\d{12}|\d{6}-\d{4}|\d{8}-\d{4}|\d{8} \d{4}|\d{6} \d{4})$",
            ErrorMessage = "Not a proper Personnummer")]
        public string PersNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int MemberHasNrVehicles { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FirstName.Equals(LastName))
            {
                yield return new ValidationResult("First and last name cannot be the same");
            }
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
}
