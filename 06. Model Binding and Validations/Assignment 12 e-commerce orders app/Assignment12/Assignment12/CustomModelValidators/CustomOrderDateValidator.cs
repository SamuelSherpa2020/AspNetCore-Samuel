using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Assignment12.CustomModelValidators
{
    public class CustomOrderDateValidator : ValidationAttribute
    {
        public string _defaultErrorMessage { get; set; } = "Order date must be greater than or equal to {0}";
        public DateTime _minimumOrderDate { get; set; }

        public CustomOrderDateValidator(string OrderDate)
        {
            _minimumOrderDate = Convert.ToDateTime(OrderDate);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime orderDate = (DateTime)value;
                if (orderDate > _minimumOrderDate)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? _defaultErrorMessage, _minimumOrderDate.ToString("yyyy-mm-dd")), new string[] { nameof(validationContext.MemberName) });
                }
            }
            else
            {
                return null;
            }
        }
    }
}
