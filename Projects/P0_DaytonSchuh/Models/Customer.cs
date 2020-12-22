using System;

namespace P0_DaytonSchuh
{
    public class Customer
    {
        private Guid id;
        private string fName;
        private string lName;
        private string password;
        private string defaultStore;
        private string username;
        private string phoneNumber;

        public Customer(string uName, string pWord)
        {
            this.username = uName;
            this.password = pWord;
        }
    }
}