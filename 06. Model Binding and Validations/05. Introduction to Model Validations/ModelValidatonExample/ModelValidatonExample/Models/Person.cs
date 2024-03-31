using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ModelValidatonExample.Models
{
    public class Person
    {
        [Required]
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmedPassword { get; set; }
        public string? Price { get; set; }

        public override string ToString()
        {
            return $"Person object - PersonName:{PersonName} Email: {Email} Phone: {Phone} Password: {Password} ConfirmePassword: {ConfirmedPassword} Price: {Price} ";
        }
    }
}
