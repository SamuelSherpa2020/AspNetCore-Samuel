using System.ComponentModel.DataAnnotations;

namespace ModelValidatonExample.DTOs
{
    public class SchoolDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }


        public override string ToString()
        {
            return ($"Name {Name} , Address {Address}");
        }
    }
}
