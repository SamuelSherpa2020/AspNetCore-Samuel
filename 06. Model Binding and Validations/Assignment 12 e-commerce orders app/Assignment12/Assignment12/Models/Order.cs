namespace Assignment12.Models
{
    public class Order
    {
        public int? OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? InvoicePrice { get; set; }

        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
