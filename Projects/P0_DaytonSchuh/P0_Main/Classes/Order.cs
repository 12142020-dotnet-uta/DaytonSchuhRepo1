using System;
using System.ComponentModel.DataAnnotations;

namespace P0_DaytonSchuh1
{
    // [DebuggerDisplay("OrderId = {OrderId}")]
    public class Order
    {
        // default constructor
        public Order() { }

        // overloaded constructor with customerid, locationid, orderdate and total
        public Order(int customerId, int locId, DateTime dateTime, Decimal total)
        {
            this.CustomerId = customerId;
            this.LocationId = locId;
            this.OrderDate = dateTime;
            this.Total = total;
        }
        // overloaded constructor with customerid, locationid, orderdate, address, city, state, country, and total
        public Order(int customerId, int locId, DateTime dateTime, string add, string city, string state, string country, Decimal total)
        {
            this.CustomerId = customerId;
            this.LocationId = locId;
            this.OrderDate = dateTime;
            this.BillingAddress = add;
            this.BillingCity = city;
            this.BillingState = state;
            this.BillingCountry = country;
            this.Total = total;
        }


        [Key]
        public int OrderId { get; set; }

        // [Required]
        public int CustomerId { get; set; }

        // [Required]
        public int LocationId { get; set; }

        // [Required]
        public DateTime OrderDate { get; set; }

        // [MaxLength(70)]
        public string BillingAddress { get; set; }

        // [MaxLength(40)]
        public string BillingCity { get; set; }

        // [MaxLength(40)]
        public string BillingState { get; set; }

        // [MaxLength(40)]
        public string BillingCountry { get; set; }

        // [Required]
        public Decimal Total { get; set; }

        // [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}