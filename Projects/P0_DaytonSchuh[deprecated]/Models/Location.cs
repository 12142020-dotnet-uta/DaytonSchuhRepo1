using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace P0_DaytonSchuh
{
    public class Location
    {
        // default constructor
        public Location() { }
        // overloaded constructor
        public Location(string name, string address)
        {
            Name = name;
            Address = address;
        }

        [Key]
        public Guid LocationID { get; set; } = Guid.NewGuid(); // PK; used as FK for inventory and orderlog
        public Inventory Inventory { get; set; }
        public OrderLog Orders { get; set; } = new OrderLog();
        public string Name { get; set; } = "Risky Business";
        public string Address { get; set; } = "Titanic Plains";
    }
}