using System;
using System.ComponentModel.DataAnnotations;

namespace P1_DaytonSchuh.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20), MinLength(5)]
        public string Username { get; set; }
        // Make sure to salt your hashbrowns
        [Required, MaxLength(20), MinLength(6) /*RegularExpression*/]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
