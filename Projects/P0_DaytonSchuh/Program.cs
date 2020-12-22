using System;
using System.Collections.Generic;
using System.Linq;

namespace P0_DaytonSchuh
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            bool programOpen = true;
            do
            {
                Console.WriteLine(
                    "Please enter the number corresponding to the action you wish to take." +
                    "\n\n1. Login 2. Register 3. Quit");
                string str = Console.ReadLine();
                int choice;
                int.TryParse(str, out choice);
                switch (choice)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Register();
                        break;
                    case 3:
                        programOpen = false;
                        Quit();
                        break;
                    default:
                        Console.WriteLine("Invalid response.");
                        break;
                }
            } while (programOpen);
        }

        static void Login()
        {
            bool logOpen = true;
            int attempts = 0;
            do
            {
                Console.WriteLine("Enter your username: ");
                string uName = Console.ReadLine();
                Console.WriteLine("Enter your password: ");
                string pWord = Console.ReadLine();
                if (validateCredentials(uName, pWord))
                {
                    // Connect to database
                    Console.WriteLine("Cool beans");
                    StorePage();
                }
                else
                {
                    attempts++;
                    Console.WriteLine("\n\tSorry. Those credentials did not match any stored in our database.");
                }
            } while (logOpen && attempts < 3);

            Console.WriteLine("Too many log in attempts. Returning to main menu...");
        }

        static void Register()
        {
            do
            {
                // get username
                Console.WriteLine("Enter your username: ");
                string uName = Console.ReadLine();

                // get password
                Console.WriteLine("Enter your password: ");
                string pWord = Console.ReadLine();

                // confirm password
                Console.WriteLine("Confirm your password: ");
                if (pWord == Console.ReadLine())
                {
                    Customer customer = new Customer(uName, pWord);
                    // add the user to our db
                    Console.WriteLine("New customer created...");
                    Login();
                }
                else
                {
                    Console.WriteLine("\n\n\tPasswords did not match.");
                }
            } while (true);
        }

        static void Quit()
        {
            Console.Clear();
            Environment.Exit(0);
        }

        static void Logout()
        {

        }

        static bool validateCredentials(string uName, string pWord)
        {
            /// use LINQ here
            // foreach (customer in customerList)
            // {
            //     if (uName == customer.username)
            //     {
            //         if (pWord == customer.password)
            //         {
            //             Console.WriteLine("Cool beans.");
            //         }
            //     }
            // }
            throw new NotImplementedException("Not yet implemented.");
        }

        static void StorePage()
        {
            throw new NotImplementedException();
        }
    }
}
