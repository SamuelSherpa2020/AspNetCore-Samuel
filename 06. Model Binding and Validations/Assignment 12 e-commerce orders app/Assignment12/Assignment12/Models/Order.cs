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
        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage ="{0} can't be blank")]
        [DisplayName("Invoice Price")]
        [CustomInvoicePriceValidator]
        public double? InvoicePrice { get; set; }

        [Required]
        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
