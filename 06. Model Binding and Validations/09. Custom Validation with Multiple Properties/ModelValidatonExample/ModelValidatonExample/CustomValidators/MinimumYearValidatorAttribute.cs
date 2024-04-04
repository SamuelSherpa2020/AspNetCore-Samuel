using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ModelValidatonExample.CustomValidators
{
    public class MinimumYearValidatorAttribute: ValidationAttribute
    {

        public int _minimumYear { get; set; } = 2000;
        public string _defaultErrorMessage { get; set; } = "Minimum Birth Year cannot be more than 2000";
        //parameterless constructor
        public MinimumYearValidatorAttribute()
        {

        }
        public MinimumYearValidatorAttribute(int MimimumYear)
        {
            _minimumYear = MimimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= _minimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? _defaultErrorMessage,_minimumYear));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                //return new ValidationResult("The value cannot be null");
                //return base.IsValid(value, validationContext);
                return null; 
            }
        }
    }
}
