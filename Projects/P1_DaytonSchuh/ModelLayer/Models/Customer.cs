using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(20, ErrorMessage = "The username must be between 3 and 20 characters.", MinimumLength = 3)]
        public string Username { get; set; }
        // Make sure to salt your hashbrowns
        [Required, StringLength(20, ErrorMessage="The password must be between 6 and 20 characters.", MinimumLength = 6)]
        public string Password { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
