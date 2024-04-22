using Assignment12.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment12.CustomModelValidators
{
    public class CustomProductValidator : ValidationAttribute
    {
        public string? _defaultErrorMessage { get; set; } = "Atleast one Product is required";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                List<Product> products = (List<Product>)value;
                if(products.Count > 0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage ?? _defaultErrorMessage, new string[] { nameof(validationContext.MemberName) });
                }
            }
            return null;
        }
    }
}
