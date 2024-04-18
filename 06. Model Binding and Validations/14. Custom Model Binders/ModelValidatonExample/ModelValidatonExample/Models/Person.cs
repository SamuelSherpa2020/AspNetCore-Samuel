using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidatonExample.CustomValidators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ModelValidatonExample.Models
{
    public class Person : IValidatableObject
    {
        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "person name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Name length should be between {2} and {1}")]
        [RegularExpression("^[A-Za-z .]+$", ErrorMessage = "{0} can only have space and . No other characters are accepted.")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage = "Valid email is required !")]
        [Required(ErrorMessage = "Email is mendatory !")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Valid phone number is required !")]
        [Required]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Compare("Password", ErrorMessage = "{0} doesn't match with {1}.")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmedPassword { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 999.99, ErrorMessage = "{0} must be between {1} and {2}")]
        public Double? Price { get; set; }


        [MinimumYearValidator(1990,ErrorMessage ="too old, must be born , after 2000")]
        public DateTime? DateOfBirth { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? TryDate { get; set; }

        [DateRangeValidator("FromDate", "TryDate", ErrorMessage = "'From Date' and 'Try Date' must be greaten  to 'To date'")]
        [Required]
        public DateTime? ToDate { get; set; }

        //[Required]
        [BindNever]
        public int? Age { get; set; }
        public override string ToString()
        {
            return $"Person object - PersonName:{PersonName} Email: {Email} Phone: {Phone} Password: {Password} ConfirmePassword: {ConfirmedPassword} Price: {Price}  Year Of Birth: {DateOfBirth}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errorValidationResults = new List<ValidationResult>();
            if (DateOfBirth.HasValue == false || Age.HasValue == false)
            {
                errorValidationResults.Add(new ValidationResult("Add Age", new[] { Age.ToString()!, nameof(DateOfBirth) }));
                //yield return new ValidationResult("Date of Birth and Age cannot be null", new[] {nameof(Age), nameof(DateOfBirth) });
                
            }
            return errorValidationResults;
        }
    }
}
