using System.ComponentModel.DataAnnotations;

namespace ModelValidatonExample.Models
{
    public class SchoolVM : IValidatableObject
    {
        [Required]
        public string? SchoolName { get; set; }

        [Required]
        public string? Address { get; set; }

        [Phone]
        public string? PhoneNo1 { get; set; }

        [Phone]
        public string? PhoneNo2 { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? Objectives { get; set; }


        public override string ToString()
        {
            return ($"School Name: {SchoolName}, Address: {Address}, PhoneNo1: {PhoneNo1}, PhoneNo2: {PhoneNo2}, Email: {Email}, Objectives : {Objectives}");
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errorList = new List<ValidationResult>();
            if (PhoneNo1.Equals(PhoneNo2))
            {
                errorList.Add(new ValidationResult("PhoneNo1 and Phone2 must not be same", new[] { nameof(PhoneNo1),nameof(PhoneNo2)}));
                return errorList;
            }
            else
            {
                return errorList;
            }
        }
    }
}
