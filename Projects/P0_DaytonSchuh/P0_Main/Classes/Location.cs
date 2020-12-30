using System.ComponentModel.DataAnnotations;

namespace P0_DaytonSchuh1
{
    //[DebuggerDisplay("LocationId = {LocationId}")]
    public class Location
    {
        // default constructor
        public Location() { }

        public Location(string add, string city, string state, string country)
        {
            this.Address = add;
            this.City = city;
            this.State = state;
            this.Country = country;
        }
        [Key]
        public int LocationId { get; set; }

        // [MaxLength(70)]
        public string Address { get; set; }

        // [MaxLength(40)]
        public string City { get; set; }

        // [MaxLength(40)]
        public string State { get; set; }

        // [MaxLength(40)]
        public string Country { get; set; }

        // [Required]
        public int OrderId { get; set; }

    }
}