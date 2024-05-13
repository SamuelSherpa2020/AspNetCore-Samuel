using Assignment12.CustomModelValidators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assignment12.Models
{
    public class Order
    {

        [DisplayName("Order Number")]
        public int? OrderNo { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [DisplayName("Order Date")]
        [CustomOrderDateValidator("2000-01-01")]
        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage ="{0} can't be blank")]
        [DisplayName("Invoice Price")]
        [CustomInvoicePriceValidator]
        public double? InvoicePrice { get; set; }

        [Required]
        [CustomProductValidator(ErrorMessage ="Atleast 1 product is required")]
        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
