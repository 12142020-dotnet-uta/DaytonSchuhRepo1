using System;
using System.ComponentModel.DataAnnotations;
namespace P1_DaytonSchuh.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        [Required]
        public decimal Total { get; set; }
    }
}
