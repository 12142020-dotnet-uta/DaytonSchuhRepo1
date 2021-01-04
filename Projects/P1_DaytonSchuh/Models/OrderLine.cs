using System;
using System.ComponentModel.DataAnnotations;

namespace P1_DaytonSchuh.Models
{
    public class OrderLine
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
