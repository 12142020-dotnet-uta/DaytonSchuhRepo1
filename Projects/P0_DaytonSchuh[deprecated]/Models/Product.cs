using System;
using System.ComponentModel.DataAnnotations;

namespace P0_DaytonSchuh
{
    public class Product
    {
        //default constructor
        public Product() { }
        // overloaded constructor
        public Product(string name, decimal price, string description)
        {
            this.Name = name;
            this.Price = price;
            this.Description = description;
        }

        [Key]
        public Guid ProductID { get; set; } = Guid.NewGuid(); // used as FK for Inventory
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}