using System;
using System.ComponentModel.DataAnnotations;

namespace P0_DaytonSchuh
{
    public class OrderLog
    {
        [Key]
        public Guid LocationID { get; set; } // FK for location
        public Order Orders { get; set; }
    }
}