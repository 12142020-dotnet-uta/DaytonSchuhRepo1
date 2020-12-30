using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P0_DaytonSchuh
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; } = Guid.NewGuid(); // PK
        public Customer Customer { get; set; }
        public DateTime RequestedAt { get; set; } = DateTime.Now;
        public Guid ProductID { get; set; }

        public List<Product> GetProductInOrder()
        {
            List<Product> list = new List<Product>();
            return list;
        }
    }
}