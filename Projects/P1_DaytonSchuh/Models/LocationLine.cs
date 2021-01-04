using System;
using System.ComponentModel.DataAnnotations;

namespace P1_DaytonSchuh.Models
{
    public class LocationLine
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
