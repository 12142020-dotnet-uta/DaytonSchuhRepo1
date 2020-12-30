using System;
using System.Linq;
using System.Collections.Generic;

namespace P0_DaytonSchuh
{
    public class StoreRepoLayer
    {
        static StoreDbContext DbContext = new StoreDbContext();
        Menu menu = new Menu();

        /// <summary>
        /// Adds customer to database after confirming they are not already in our database.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Customer</returns>
        public Customer RegisterCustomer(string username, string password)
        {
            Customer customer = DbContext.customers.Where(x => x.Username == username).FirstOrDefault();

            if (customer == null)
            {
                customer = new Customer()
                {
                    Username = username,
                    Password = password
                };
                DbContext.customers.Add(customer);
                DbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("That username is taken. Perhaps you meant to log in?");
                return null;
            }

            return customer;
        }// END RegisterCustomer



        /// <summary>
        /// Converts string input from the user to its int32 variant. If unsuccessful, returns -1
        /// </summary>
        /// <param name="input"></param>
        /// <returns>int</returns>
        public int ConvertStringToInt(string input)
        {
            int result;
            if (int.TryParse(input, out result))
            {
                return result;
            }
            else return -1;
        }// END ConvertStringToInt



        /// <summary>
        /// Validates login credentials from user input.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>true if valid credentials, otherwise returns false</returns>
        public bool ValidLoginCredentials(string username, string password)
        {
            if (DbContext.customers.Any(x => x.Username == username && x.Password == password))
            {
                return true;
            }
            else return false;
        }// END ValidLoginCredentials



        /// <summary>
        /// Returns list of customers.
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            return DbContext.customers.ToList();
        }

        /// <summary>
        /// Returns list of locations.
        /// </summary>
        /// <returns></returns>
        public List<Location> GetLocations()
        {
            return DbContext.locations.ToList();
        }

        /// <summary>
        /// Returns list of orders.
        /// </summary>
        /// <returns>List<\Order></returns>
        public List<Order> GetOrders()
        {
            return DbContext.orders.ToList();
        }

        /// <summary>
        /// Returns list of products.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            return DbContext.products.ToList();
        }

        public void Navigate(int command)
        {
            switch (command)
            {
                case 1:
                    // let user try to log in
                    if (Login())
                    {
                        // if successful, they get to shop
                        PickAStore();
                    }
                    // else go back to main menu
                    else menu.Display(menu.menus[0]);

                    break;
                case 2:
                    // let user register
                    Register();
                    // go back to main menu
                    menu.Display(menu.menus[0]);
                    break;
                case 3:
                    Quit();
                    break;
                default:
                    break;
            }
        }

        public void Start()
        {
            //Populate db
            //Worked.
            /*Console.WriteLine("Populating Locations...");
            DbContext.locations.Add(new Location());
            DbContext.locations.Add(new Location("Risky Business", "Void Fields"));
            DbContext.locations.Add(new Location("Risky Business", "Distant Roost"));
            DbContext.locations.Add(new Location("Risky Business", "Bazaar Between Time"));

            //Worked.
            Console.WriteLine("Populating Products...");
            DbContext.products.Add(new Product("Death Mark", (decimal)8.00, "Enemies with 4 or more debuffs are marked for death, increasing damage taken by 50% from all sources for 7 seconds."));
            DbContext.products.Add(new Product("Bustling Fungus", (decimal)5.33, "After standing still for 2 seconds, create a zone that heals for 4.5% of your health every second to all allies within 3m."));
            DbContext.products.Add(new Product("Hopoo Feather", (decimal)20.00, "Gain +1 maximum jump count."));
            DbContext.products.Add(new Product("Titanic Knurl", (decimal)32.00, "Increase maximum health by 40 and base health regeneration by +1.6 hp/s."));
            DbContext.products.Add(new Product("Gesture of the Drowned", (decimal)15.50, "Reduce Equipment cooldown by 50%. Forces your Equipment to activate whenever it is off cooldown."));
            DbContext.SaveChanges();

            // Void Fields
            Console.WriteLine("Populating Inventories...");
            DbContext.locations.FirstOrDefault(x => x.Address == "Void Fields").Inventory = new Inventory().AddProduct(DbContext.products.SingleOrDefault(x => x.Name == "Death Mark"), 4);
            Inventory inv = DbContext.locations.FirstOrDefault(x => x.Address == "Void Fields").Inventory.AddProduct(DbContext.products.SingleOrDefault(x => x.Name == "Death Mark"), 4);
            if (inv != null)
            {
                DbContext.inventories.Add(inv);
                DbContext.SaveChanges();
            }
            inv = DbContext.locations.FirstOrDefault(x => x.Address == "Void Fields").Inventory.AddProduct(DbContext.products.SingleOrDefault(x => x.Name == "Death Mark"), 11);
            if (inv != null)
            {
                DbContext.inventories.Add(inv);
                DbContext.SaveChanges();
            }
            inv = DbContext.locations.FirstOrDefault(x => x.Address == "Void Fields").Inventory.AddProduct(DbContext.products.SingleOrDefault(x => x.Name == "Bustling Fungus"), 4);
            if (inv != null)
            {
                DbContext.inventories.Add(inv);
                DbContext.SaveChanges();
            }*/


            // display main menu
            menu.Display(menu.menus[0]);
        }



        /**********************************************
        * Login System
        *
        * Request username
        * Request password
        *
        **********************************************/
        public bool Login()
        {
            int attempts = 0;
            do
            {
                menu.Display(menu.menus[1]);
                Console.WriteLine("\nPlease enter your username: ");
                string username = Console.ReadLine();
                Console.WriteLine("\nPlease enter your password: ");
                string password = Console.ReadLine();
                if (ValidLoginCredentials(username, password))
                {
                    return true;
                }
                else
                {
                    attempts++;
                    Console.WriteLine($"The username or password you entered is incorrect. You have {3 - attempts} remaining attempt(s).");
                }
            } while (attempts < 3);

            Console.Clear();
            Console.WriteLine("Your attempts were futile; returning to Main Menu...");
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            return false;
        }// END Login



        public void Register()
        {
            bool registered = false;
            do
            {
                Console.WriteLine("Please enter a username: ");
                string username = Console.ReadLine();
                Console.WriteLine("\nPlease enter your password: ");
                string password = Console.ReadLine();
                Console.WriteLine("\nPlease confirm your password: ");
                // passwords matched, attempt to register
                if (password == Console.ReadLine())
                {
                    if (RegisterCustomer(username, password) != null)
                    {
                        registered = true;
                    }
                }
                else
                {
                    Console.WriteLine("The passwords did not match.");
                }
            } while (!registered);
        }// END Register



        /**********************************************
        * Store System
        *
        * Display list of stores
        * Request user store
        * Display list of available products
        * Request user product
        * Display particular product (available amount and description)
        * Display menu to back out or add to cart
        *
        **********************************************/
        public void PickAStore()
        {
            do
            {
                // Display Store menu
                menu.Display(menu.menus[3]);
                // Display all locations
                int count = 1;
                var locs = DbContext.locations.OrderBy(l => l.Address).ToList();
                foreach (Location loc in locs)
                {
                    Console.WriteLine($"{count++}." + loc.Name);
                }

                // Pick a store
                Console.WriteLine("Enter the integer corresponding to the location you wish to search.");
                string userInput = Console.ReadLine();
                // try and parse user input
                int.TryParse(userInput, out count);

                // check for invalid input
                if (count > locs.Count || count < 1)
                {
                    Console.WriteLine("I'm invalidating your response, as well as your life.");
                }

                // otherwise, we gucci
                else
                {
                    var prods = DbContext.locations.SingleOrDefault(x => x.LocationID == locs[count - 1].LocationID).Inventory.ReturnAllProducts(locs[count - 1]);
                    //foreach (var p in prods) { Console.WriteLine(p.Name); }
                    // menu.Display(menu.menus[]);
                    //}
                    // sort by name
                    // prods.OrderBy(x=>x.Name);
                    // option to sort by price
                    // prods.OrderBy(x=>x.Price);
                    // option to sort by id
                    // prods.OrderBy(x=>x.ProductID);
                    if (prods.Count == 0)
                    {
                        Console.WriteLine("No products to be found.");
                    }
                    else
                    {
                        // Display all products at location
                        foreach (Product product in prods)
                        {
                            Console.WriteLine(
                            "|----------------------------------------------------------------------------------------------------------------" +
                            "\n| Item: " + product.Name + " | Price: " + product.Price + " | Quantity: " + DbContext.locations.SingleOrDefault(x => x.LocationID == locs[count - 1].LocationID).Inventory.ReturnQuantityOfItem(product) +
                            "\n| Description: " + product.Description +
                            "\n|----------------------------------------------------------------------------------------------------------------");
                        }
                        Shop();
                    }
                }
            } while (true);
        }// END Store

        public void Shop()
        {
            menu.Display(menu.menus[4]);
        }



        /**********************************************
        * Cart System 
        *
        * Ask user how many they'd like to add
        * Add chosen items to cart
        * Temporarily decrement from available product
        *
        **********************************************/
        public void Cart()
        {
            menu.Display(menu.menus[5]);
            Console.WriteLine("Enter the integer of the product you'd like to add to your cart: ");
            int itemId = ConvertStringToInt(Console.ReadLine());
            Console.WriteLine("Enter the quantity you'd like to add: ");
            int quantity = ConvertStringToInt(Console.ReadLine());
        }// END Cart



        /**********************************************
        * Check Out System
        * 
        * Display list of items in cart and total price
        * Request user to confirm
        *
        **********************************************/
        static void CheckOut() { }// END CheckOut



        /*Quit*/
        public void Quit()
        {
            // Thank user
            menu.Display(menu.menus[6]);
            // Wait 3 seconds
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
            // Quit the application
            Environment.Exit(0);
        }// END Quit



    }// END StoreRepoLayer
}// END namespace