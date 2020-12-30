using System.ComponentModel.DataAnnotations;

namespace P0_DaytonSchuh1
{
    // [DebuggerDisplay("LocationLineId = {LocationLineId}")]
    public class LocationLine
    {
        // default constructor
        public LocationLine() { }

        public LocationLine(int locId, int prodId, decimal price, int quantity)
        {
            this.LocationId = locId;
            this.ProductId = prodId;
            this.UnitPrice = price;
            this.Quantity = quantity;
        }
        [Key]
        public int LocationLineId { get; set; }

        // [Required]
        public int LocationId { get; set; }

        // [Required]
        public int ProductId { get; set; }

        // [Required]
        public decimal UnitPrice { get; set; }

        // [Required]
        public int Quantity { get; set; }

        // [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}