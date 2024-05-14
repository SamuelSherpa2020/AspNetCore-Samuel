using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.Core.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage ="Name Can't be blank")]
        public string? PersonName { get; set; }

        [Required(ErrorMessage = "Email Can't be blank")]
        [EmailAddress(ErrorMessage ="Email should be in proper format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber Can't be blank")]
        [RegularExpression("^[0-9]*$",ErrorMessage ="Phone number must contain only numbers")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Password Can't be blank")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Can't be blank")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage =("{0} doesn't match with {1}"))]
        [DisplayName("Confirmed Password")]
        public string? ConfirmPassword { get; set; }
    }
}
