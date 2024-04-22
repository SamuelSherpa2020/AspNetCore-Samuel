using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assignment12.Models
{
    public class Product
    {
        [Required(ErrorMessage ="{0} can't be blank")]
        [DisplayName("Product Code")]
        [Range(1,int.MaxValue,ErrorMessage ="{0} should be a valid number")]
        public int? ProductCode { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [DisplayName("Product Price")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be a valid number")]

        public double Price { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [DisplayName("Product Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be a valid number")]

        public int Quantity { get; set; }
    }
}
