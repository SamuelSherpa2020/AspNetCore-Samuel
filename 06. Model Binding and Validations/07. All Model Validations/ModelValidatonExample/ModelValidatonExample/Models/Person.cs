using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelValidatonExample.Models
{
    public class Person
    {
        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "person name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} length should be between {2} and {1}")]
        public string? PersonName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Password { get; set; }
        public string? ConfirmedPassword { get; set; }

        [Range(0, 999.99, ErrorMessage = "{0} must be between {1} and {2}")]
        public string? Price { get; set; }

        public override string ToString()
        {
            return $"Person object - PersonName:{PersonName} Email: {Email} Phone: {Phone} Password: {Password} ConfirmePassword: {ConfirmedPassword} Price: {Price} ";
        }
    }
}
