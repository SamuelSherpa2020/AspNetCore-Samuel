using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidatonExample.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string _fromDate { get; set; }

        //below is property that i tried to learn, to see if we could compare with more than one property.
        public string _tryDate { get; set; }
        public DateRangeValidatorAttribute(string FromDatePar,string TryDatePar)
        {
            _fromDate = FromDatePar;
            _tryDate = TryDatePar;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                // parsing given value into DateTime

                DateTime _toDate = Convert.ToDateTime(value);

                //var _fromdate = validationContext.ObjectInstance.GetType();
                //get the value of FromDatePar model property
                PropertyInfo? _fromDateProperty = validationContext.ObjectType.GetProperty(_fromDate);
                PropertyInfo? _tryDateProperty = validationContext.ObjectType.GetProperty(_tryDate);

                if (_fromDateProperty != null && _tryDateProperty !=null)
                {
                    DateTime _fromDateValue = Convert.ToDateTime(_fromDateProperty!.GetValue(validationContext.ObjectInstance));
                    DateTime _tryDateValue = Convert.ToDateTime(_tryDateProperty!.GetValue(validationContext.ObjectInstance)); 
                    if (_tryDateValue > _toDate)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { _fromDate,_tryDate, validationContext.MemberName! });
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                return null;  
            }
            else
            {
                return null;
            }
        }
    }
}
