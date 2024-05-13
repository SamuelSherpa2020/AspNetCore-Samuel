using Assignment12.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Assignment12.CustomModelValidators
{
    public class CustomInvoicePriceValidator : ValidationAttribute
    {

        public string? _defaultErrorMessage { get; set; } = "Invoice Price must be equal to the total cost of all products (i.e. {0} in the order)";
        public CustomInvoicePriceValidator()
        {

        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                PropertyInfo? productPropertyInfo = validationContext.ObjectType.GetProperty(nameof(Order.Products));
                if (productPropertyInfo != null)
                {
                    List<Product> productsList = (List<Product>)productPropertyInfo.GetValue(validationContext.ObjectInstance)!;

                    double totalPrice = 0;
                    foreach (Product product in productsList)
                    {
                        totalPrice += product.Price * product.Quantity;
                    }
                    double invoicePrice = (double)value;
                    if (totalPrice > 0)
                    {
                        if (totalPrice != invoicePrice)
                        {
                            return new ValidationResult(string.Format(ErrorMessage ?? _defaultErrorMessage!, totalPrice), new string[] { nameof(validationContext.MemberName) });
                        }
                    }
                    else
                    {
                        return new ValidationResult("No products found to validate invoice price", new string[] { nameof(validationContext.MemberName) });
                    }
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("No products found to validate invoice price", new string[] { nameof(validationContext.MemberName) });
                }
            }
            else
            {
                return null;
            }
        }
    }
}
