using System;
using System.ComponentModel.DataAnnotations;

namespace P0_DaytonSchuh
{
    public class Customer
    {
        private string password;
        private string username;
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        public string Username
        {
            get { return username; }
            set
            {
                if (value is string && value.Length < 20 && value.Length >= 4) { username = value; }
                else { Console.WriteLine("The username must be at least 4 characters long."); }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value is string && value.Length < 20 && value.Length >= 5) { password = value; }
                else { Console.WriteLine("The password must be at least 5 characters long."); }
            }
        }

    }
}