using System;
using System.ComponentModel.DataAnnotations;

namespace P0_DaytonSchuh1
{
    public class Product
    {
        // default constructor
        public Product() { }

        public Product(string name, Decimal price, string desc)
        {
            this.Name = name;
            this.UnitPrice = price;
            this.Description = desc;
        }

        [Key]
        public int ProductId { get; set; }

        // [Required, MaxLength(200)]
        public string Name { get; set; }

        // [Required]
        public Decimal UnitPrice { get; set; }

        // [Required, MaxLength(200)]
        public string Description { get; set; }
    }
}