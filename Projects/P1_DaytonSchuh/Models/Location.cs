using System;
using System.ComponentModel.DataAnnotations;

namespace P1_DaytonSchuh.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int OrderId { get; set; }
    }
}
