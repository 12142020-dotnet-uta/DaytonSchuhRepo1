using System.ComponentModel.DataAnnotations;

namespace P0_DaytonSchuh1
{


    //[DebuggerDisplay("{FirstName} {LastName} (CustomerId = {CustomerId})")]
    public class Customer
    {
        // default constructor
        public Customer() { }
        public Customer(string fname, string lname)
        {
            this.FirstName = fname;
            this.LastName = lname;
        }
        public Customer(string fname, string lname, string add, string city, string state, string country)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Address = add;
            this.City = city;
            this.State = state;
            this.Country = country;
        }


        [Key]
        public int CustomerId { get; set; }

        //[Required, MaxLength(20)]
        public string FirstName { get; set; }

        //[Required, MaxLength(20)]
        public string LastName { get; set; }

        // [MaxLength(70)]
        public string Address { get; set; }

        // [MaxLength(40)]
        public string City { get; set; }

        // [MaxLength(40)]
        public string State { get; set; }

        // [MaxLength(40)]
        public string Country { get; set; }

    }
}