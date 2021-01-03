using System;
using System.Collections.Generic;


/*1) log in, 
2) choose a store from a list of locations, 
3) view all the available products of that store, 
4) fill a cart with a user-chosen product, 
5) choose the number of products, and then 
6) check out.*/

namespace P0_DaytonSchuh1
{
    class Program
    {
        static RepoLayer context = new RepoLayer();
        static void Main(string[] args)
        {
            //context.Populate();
            Console.WriteLine("Welcome to Risky Business!");

            // START LOGIN/QUIT SECTION
            int logInOrQuitInt;
            do
            {
                logInOrQuitInt = MainMenu();
                if (logInOrQuitInt == 2) Quit();

                //log in or create a new customer. unique fName and lName means create a new customer, other wise, grab the existing customer
                string[] userNamesArray = GetUserNames();

                Customer cust = new Customer();
                if (userNamesArray.Length == 1)                                         //if the user unputted just one name
                { cust = context.CreateCustomer(fName: userNamesArray[0]); }
                else if (userNamesArray.Length > 1)                                     //if the user unputted 2 names
                { cust = context.CreateCustomer(userNamesArray[0], userNamesArray[1]); }
                else
                { throw new ArgumentNullException("User input for name was invalid."); } // if the userNamesArray is empty.
                // END LOGIN/QUIT SECTION

                // START LOCATION SELECTION SECTION
                Location location;
                int choice;
                do //location loop starts here.
                {
                    // menu
                    Console.WriteLine("1. Shop 2. Find A Friend 3. View Your Orders");

                    //get user input
                    choice = context.ConvertStringToInt(Console.ReadLine());
                    if (choice == 1) break;
                    else if (choice == 2) SearchACustomer();
                    else if (choice == 3) ViewOrders(cust);
                    else Console.WriteLine("Bruh what the heck. 1 or 2.");
                } while (true);

                /* SHOPPING */
                // START LOCATION SELECTION SECTION
                do
                {
                    // list all locations
                    ListAvailableLocations();

                    // set the users location choice
                    location = SetLocation();
                    // END LOCATION SELECTION SECTION

                    Console.WriteLine($"Would you like to shop or view orders at {location.Address} in {location.City}?\n" +
                    "\t1. Shop 2. View Orders \n\t(Or -1 if you'd like to go back)");
                    choice = context.ConvertStringToInt(Console.ReadLine());
                    if (choice == 2)
                    {
                        ListOrdersAtLocation(location);
                    }
                    else if (choice == 1)
                    {
                        // START PRODUCT SELECTION SECTION
                        Product product;
                        LocationLine locationLine = new LocationLine();
                        do // store selected, display products
                        {

                            Console.WriteLine("Here's what we have to offer!");

                            // show products at that location (aka our inventory)
                            DisplayProducts(location);

                            // get the product they want from that location
                            product = BrowseProducts(location, ref locationLine);
                            // END PRODUCT SELECTION SECTION
                            int amount;
                            // START CHOOSE NUMBER OF PRODUCT TO ADD SECTION
                            do
                            {
                                // list current item they're looking at

                                Console.WriteLine("How many would you like to add to your cart? \n\t(Or -1 if you'd like to go back.)");

                                // get user response
                                amount = context.ConvertStringToInt(Console.ReadLine());

                                if(amount == -1){break;}

                                // check if inventory has enough to satisfy request
                                else if (amount <= context.QuantityOfProduct(product, locationLine))
                                {
                                    // temporarily subtract from location
                                    context.SubtractProductFromLocation(location, product, choice);
                                    break;
                                }
                                else { Console.WriteLine("Sorry, we don't have enough in stock. Try again."); }
                            } while (true);
                            // END CHOOSE NUMBER OF PRODUCT TO ADD SECTION

                            // START CHECKOUT SECTION
                            Console.WriteLine("Would you like to checkout?(1.Yes 2.No)" +
                            "\n(WARNING! Selecting no will restart the process.)");

                            // get user response
                            choice = context.ConvertStringToInt(Console.ReadLine());
                            if (choice == 2) context.AddProductToLocation(location, product, amount);

                            // START ORDER SECTION
                            // amount check so we don't add orders with no total
                            else if (amount > 0 && choice == 1) context.HandleOrder(cust, location, product, amount);
                            // END ORDER SECTION

                            // END CHECKOUT SECTION
                        } while (choice != 2);
                    }
                    else if(choice == -1)
                    {
                        break;
                    }
                    else Console.WriteLine("well at least you tried.");
                } while (true);

            } while (true);
        }



        /// <summary>
        /// Gives the user the choice to log in or quit the program
        /// </summary>
        /// <returns></returns>
        public static int MainMenu()
        {
            int logInOrQuitInt;
            do
            {
                Console.WriteLine("Enter 1 to log in and 2 to quit the program.");
                //call a method to validate user input.
                logInOrQuitInt = context.ConvertStringToInt(Console.ReadLine());
                if (logInOrQuitInt == -1) Console.WriteLine("Well, at least you tried... Try again.");
            } while (logInOrQuitInt != 1 && logInOrQuitInt != 2);// loop runs till the user selects 1 or 2
            return logInOrQuitInt;
        }

        /// <summary>
        /// Gets the users name and returns a  string array of those names.
        /// If the user inputs more than 2 names only the first 2 are taken.
        /// </summary>
        /// <returns></returns>
        public static string[] GetUserNames()
        {
            string[] userNamesArray;
            do
            {
                Console.WriteLine("\n\tPlease enter your first and last name.\n\tIf you enter unique first and last name I will create a new customer.\n");
                userNamesArray = Console.ReadLine().Trim().Split(' ');
            } while (userNamesArray[0] == "");
            return userNamesArray;
        }

        /// <summary>
        /// Writes a thank you message before exiting the environment.
        /// </summary>
        public static void Quit()
        {
            Console.Clear();
            Console.WriteLine("Thanks for stopping by!");
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            Environment.Exit(0);
        }

        /// <summary>
        /// Displays all locations stored in our database.
        /// </summary>
        public static void ListAvailableLocations()
        {
            int count = 1;
            List<Location> locationList = context.GetLocations();
            foreach (var loc in locationList)
            {
                Console.WriteLine($"{count++}. Risky Business in {loc.City}");
            }
        }

        /// <summary>
        /// Displays all current products at a given location.
        /// </summary>
        /// <param name="location"></param>
        public static void DisplayProducts(Location location)
        {
            int count = 1;
            List<LocationLine> locationLineList = context.GetLocationLines(location);
            // display the products at specified location
            foreach (var loc in locationLineList)
            {
                Console.WriteLine($"{count++}. {context.GetProductFromId(loc.ProductId).Name} | Quantity: {loc.Quantity} | Price : {loc.UnitPrice}");
            }
        }

        /// <summary>
        /// Allow user to select a product for purchase. Manipulates a location line passed by reference.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="locationLine"></param>
        /// <returns>Product</returns>
        public static Product BrowseProducts(Location location, ref LocationLine locationLine)
        {
            List<LocationLine> locationLineList = context.GetLocationLines(location);
            int productSelected;
            Product product;
            do
            {
                Console.WriteLine("Which item would you like to purchase?");

                // get userinput
                productSelected = context.ConvertStringToInt(Console.ReadLine());

                // validate user input
                if (productSelected > 0 || productSelected < locationLineList.Count)
                {
                    // cycle location list
                    foreach (var loc in locationLineList)
                    {
                        // find a matching product
                        if (loc.ProductId == locationLineList[productSelected - 1].ProductId)
                        {
                            // get the product
                            product = context.GetProductFromId(loc.ProductId);
                            locationLine = loc;
                            //return the product
                            return product;
                        }
                    }

                }
                else Console.WriteLine("Well, at least you tried. Try again.");

            } while (true);
        }

        /// <summary>
        /// After recieveing user input, attempts to find and assign that location. If user input does not fall within acceptable range, they are asked to try again until they get it right.
        /// </summary>
        /// <returns>Location</returns>
        public static Location SetLocation()
        {
            int i = 0;
            do
            {
                // ask user
                Console.WriteLine("Enter an integer corresponding to your location.");

                // get user input
                i = context.ConvertStringToInt(Console.ReadLine());

                // check if user input fell in range
                if (i > 0 || i < context.GetLocations().Count)
                    return context.SetUserLocation(i);

                // boo! >:[ the user is dumb
                else Console.WriteLine("Well, at least you tried. Try again.");
            } while (true);
        }

        /// <summary>
        /// Ask user to provide a name to search. Write to console the results of the search.
        /// </summary>
        public static void SearchACustomer()
        {
            string[] names = GetUserNames();
            Customer c = context.FindACustomer(names);
            if (c != null)
            {
                Console.WriteLine($"We found {c.FirstName} {c.LastName}!");
            }
            else Console.WriteLine($"Unfortunately, we couldn't find a user with that name!");
        }

        /// <summary>
        /// Displays all orders at a given location.
        /// </summary>
        /// <param name="location"></param>
        public static void ListOrdersAtLocation(Location location)
        {
            List<Order> orderList = context.GetOrderListForLocation(location);
            foreach (var order in orderList)
            {
                Console.WriteLine(order.OrderId + " | " + order.OrderDate +
                $"\n\t{order.Total}");
            }
        }

        public static void ViewOrders(Customer customer)
        {
            do
            {
                int count = 1;
                // get list of customer orders
                List<Order> orderList = context.GetCustomerOrders(customer);
                // display list ordered by date
                foreach (var order in orderList)
                {
                    Console.WriteLine($"{count++}. {order.OrderDate} -- {order.Total}");
                }

                Console.WriteLine("Enter the integer corresponding to the order you'd like to view." +
                "\n\t(Or -1 if you'd like to go back)");
                int choice = context.ConvertStringToInt(Console.ReadLine());
                if (choice == -1) { break; }
                else
                {
                    Order order = context.GetOrderById(orderList[choice - 1].OrderId);
                    ViewOrderDetails(order);
                }
            } while (true);
        }

        public static void ViewOrderDetails(Order order)
        {
            Console.WriteLine($"Order #:{order.OrderId} -- Date:{order.OrderDate}");
            List<OrderLine> orderLineList = context.GetOrderLinesForOrder(order);
            foreach (var line in orderLineList)
            {
                Console.WriteLine($"{context.GetProductFromId(line.ProductId).Name} -- {line.UnitPrice} -- {line.Quantity}");
            }
            Console.WriteLine($"\tTotal: {order.Total}");
        }
    }
}
