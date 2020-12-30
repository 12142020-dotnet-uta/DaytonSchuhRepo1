using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P0_Main;

namespace P0_DaytonSchuh1
{
    public class RepoLayer : RepoInterface
    {
        static P0_DbContext DbContext = new P0_DbContext();
        DbSet<Customer> customers = DbContext.customers;
        DbSet<Order> orders = DbContext.orders;
        DbSet<Location> locations = DbContext.locations;
        DbSet<Product> products = DbContext.products;
        DbSet<LocationLine> locationLines = DbContext.locationLines;
        DbSet<OrderLine> orderLines = DbContext.orderLines;

        public RepoLayer() { }

        public RepoLayer(P0_DbContext context)
        {
            DbContext = context;
            customers = context.customers;
            orders = context.orders;
            locations = context.locations;
            products = context.products;
            locationLines = context.locationLines;
            orderLines = context.orderLines;
        }

        /// <summary>
        /// Used to populate the database with fake information to get started. Should be commented out in Program.cs after first run of the program.
        /// </summary>
        public void Populate()
        {
            Console.WriteLine("Populating Products...");
            products.Add(new Product("Death Mark", (decimal)8.00, "Enemies with 4 or more debuffs are marked for death, increasing damage taken by 50% from all sources for 7 seconds."));
            products.Add(new Product("Bustling Fungus", (decimal)5.33, "After standing still for 2 seconds, create a zone that heals for 4.5% of your health every second to all allies within 3m."));
            products.Add(new Product("Hopoo Feather", (decimal)20.00, "Gain +1 maximum jump count."));
            products.Add(new Product("Titanic Knurl", (decimal)32.00, "Increase maximum health by 40 and base health regeneration by +1.6 hp/s."));
            products.Add(new Product("Gesture of the Drowned", (decimal)15.50, "Reduce Equipment cooldown by 50%. Forces your Equipment to activate whenever it is off cooldown."));
            DbContext.SaveChanges();

            Console.WriteLine("Populating Locations...");
            locations.Add(new Location("Risky Business", "Titanic Plains", "Despair", "US"));
            locations.Add(new Location("Risky Business", "Void Fields", "Despair", "US"));
            locations.Add(new Location("Risky Business", "Distant Roost", "Despair", "US"));
            locations.Add(new Location("Risky Business", "Bazaar Between Time", "Despair", "US"));

            Console.WriteLine("Populating LocationLines...");
            locationLines.Add(new LocationLine(1, 1, (decimal)10.50, 2));
            locationLines.Add(new LocationLine(1, 2, (decimal)8.00, 3));
            locationLines.Add(new LocationLine(1, 4, (decimal)30.00, 2));
            locationLines.Add(new LocationLine(2, 2, (decimal)8.00, 8));
            locationLines.Add(new LocationLine(2, 3, (decimal)19.99, 4));

            Console.WriteLine("Populating Orders...");
            orders.Add(new Order(1, 1, DateTime.Now, "123 Easy Street", "Faking", "Onomatopoeia", "US", (decimal)31.50));

            Console.WriteLine("Populating OrderLines...");
            orderLines.Add(new OrderLine(1, 1, 1, (decimal)10.50, 3));

            Console.WriteLine("Populating Customers...");
            customers.Add(new Customer("Dayton", "Schuh", "123 Easy Street", "Faking", "Onomatopoeia", "US"));
        }


        /// <summary>
        /// Converts string input from the user to its int32 variant. If unsuccessful, returns -1
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int ConvertStringToInt(string input)
        {
            int result;
            bool choice = int.TryParse(input, out result);
            if (choice == false)
            {
                return -1;
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Adds customer to database after confirming they are not already in our database.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Customer</returns>
        public Customer CreateCustomer(string fName = "null", string lName = "null")
        {
            Customer cust = new Customer();
            cust = customers.Where(x => x.FirstName == fName && x.LastName == lName).FirstOrDefault();

            if (cust == null)
            {
                cust = new Customer()
                {
                    FirstName = fName,
                    LastName = lName
                };

                customers.Add(cust);
                DbContext.SaveChanges();
            }

            return cust;
        }// END RegisterCustomer

        /// <summary>
        /// Alter quantity of a given location's associated product by given amount.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        public void SubtractProductFromLocation(Location location, Product product, int amount)
        {
            LocationLine locationLine = locationLines.Where(x => x.LocationId == location.LocationId && x.ProductId == product.ProductId).FirstOrDefault();
            locationLine.Quantity -= amount;
            DbContext.SaveChanges();
        }

        /// <summary>
        /// Alter quantity of a given location's associated product by given amount.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        public void AddProductToLocation(Location location, Product product, int amount)
        {
            LocationLine locationLine = locationLines.Where(x => x.LocationId == location.LocationId && x.ProductId == product.ProductId).FirstOrDefault();
            locationLine.Quantity += amount;
            DbContext.SaveChanges();
        }

        /// <summary>
        /// Returns a list of all locations in our database.
        /// </summary>
        /// <returns>List(Location)</returns>
        public List<Location> GetLocations()
        {
            return locations.ToList();
        }

        /// <summary>
        /// Returns a list of all products in our database
        /// </summary>
        /// <returns>List(Product)</returns>
        public List<Product> GetProducts()
        {
            return products.ToList();
        }

        /// <summary>
        /// Returns a list of all location lines of a specified location.
        /// </summary>
        /// <param name="location"></param>
        /// <returns>List(LocationLine)</returns>
        public List<LocationLine> GetLocationLines(Location location)
        {
            return locationLines.Where(x => x.LocationId == location.LocationId).ToList();
        }

        /// <summary>
        /// Returns the product of a specified location line.
        /// </summary>
        /// <param name="locationLine"></param>
        /// <returns>Product</returns>
        public Product GetSpecificProduct(LocationLine locationLine)
        {
            return products.Where(x => x.ProductId == locationLine.ProductId).FirstOrDefault();
        }

        /// <summary>
        /// Returns the quantity of a product on a specified location line.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="l"></param>
        /// <returns>int</returns>
        public int QuantityOfProduct(Product p, LocationLine l)
        {
            return locationLines.Where(x => x.ProductId == p.ProductId && x.LocationLineId == l.LocationLineId).FirstOrDefault().Quantity;
        }

        /// <summary>
        /// Returns the location the user wishes to access.
        /// </summary>
        /// <param name="i"></param>
        /// <returns>Location</returns>
        public Location SetUserLocation(int i)
        {
            return locations.Where(x => x.LocationId == i).FirstOrDefault();
        }

        /// <summary>
        /// Returns a customer where specified names match our database.
        /// </summary>
        /// <param name="names"></param>
        /// <returns>Customer</returns>
        public Customer FindACustomer(string[] names)
        {
            if (names.Length == 1) return customers.Where(x => x.FirstName == names[0]).FirstOrDefault();
            else return customers.Where(x => x.FirstName == names[0] && x.LastName == names[1]).FirstOrDefault();
        }

        /// <summary>
        /// Returns a product 
        /// </summary>
        /// <param name="prodId"></param>
        /// <returns></returns>
        public Product GetProductFromId(int prodId)
        {
            return products.Where(x => x.ProductId == prodId).FirstOrDefault();
        }

        /// <summary>
        ///  Create a new order, process and package it for delivery to the database.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="location"></param>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        public void HandleOrder(Customer customer, Location location, Product product, int amount)
        {
            // create order instance
            Order order = new Order(customer.CustomerId, location.LocationId, DateTime.Now, product.UnitPrice * amount);

            orders.Add(order);
            // add order to orderline
            orderLines.Add(new OrderLine(order.OrderId, order.CustomerId, product.ProductId, product.UnitPrice, amount));

            // commit to db
            DbContext.SaveChanges();
        }

        /// <summary>
        /// Returns all orders stored at a specified location.
        /// </summary>
        /// <param name="location"></param>
        /// <returns>List(Order)</returns>
        public List<Order> GetOrderListForLocation(Location location)
        {
            return orders.Where(x => x.LocationId == location.LocationId).ToList();
        }

        public List<Order> GetCustomerOrders(Customer customer)
        {
            return orders.Where(x => x.CustomerId == customer.CustomerId).OrderBy(x => x.OrderDate).ToList();
        }

        /// <summary>
        /// Returns all lines of an order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns>List(OrderLines)</returns>
        public List<OrderLine> GetOrderLinesForOrder(Order order)
        {
            return orderLines.Where(x => x.OrderId == order.OrderId).ToList();
        }

        /// <summary>
        /// Returns an order from a specified order id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>Order</returns>
        public Order GetOrderById(int orderId)
        {
            return orders.Where(x => x.OrderId == orderId).FirstOrDefault();
        }

        /// <summary>
        /// Returns a list of customers from database.
        /// </summary>
        /// <returns>List(Customer)</returns>
        public List<Customer> GetCustomers()
        {
            return customers.ToList();
        }

        /// <summary>
        /// Returns a list of location lines from database.
        /// </summary>
        /// <returns>List(LocationLine)</returns>
        public List<LocationLine> GetLocationLines()
        {
            return locationLines.ToList();
        }

        /// <summary>
        /// Returns a list of orders from database.
        /// </summary>
        /// <returns>List(Order)</returns>
        public List<Order> GetOrders()
        {
            return orders.ToList();
        }

        /// <summary>
        /// Returns a list of order lines from database.
        /// </summary>
        /// <returns>List(OrderLines)</returns>
        public List<OrderLine> GetOrderLines()
        {
            return orderLines.ToList();
        }

    }
}