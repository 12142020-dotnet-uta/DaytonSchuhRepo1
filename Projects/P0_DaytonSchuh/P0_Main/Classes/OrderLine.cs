using System.ComponentModel.DataAnnotations;

namespace P0_DaytonSchuh1
{
    // [DebuggerDisplay("OrderLineId = {OrderLineId}")]
    public class OrderLine
    {
        // default constructor
        public OrderLine() { }
        public OrderLine(int orderId, int customerId, int prodId, decimal price, int quantity)
        {
            this.OrderId = orderId;
            this.CustomerId = customerId;
            this.ProductId = prodId;
            this.UnitPrice = price;
            this.Quantity = quantity;
        }

        [Key]
        public int OrderLineId { get; set; }

        // [Required]
        public int OrderId { get; set; }

        // [Required]
        public int CustomerId { get; set; }

        // [Required]
        public int ProductId { get; set; }

        // [Required]
        public decimal UnitPrice { get; set; }

        // [Required]
        public int Quantity { get; set; }

        // [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        // [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}