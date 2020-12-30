using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace P0_DaytonSchuh
{
    public class Test
    {
        static StoreDbContext DbContext = new StoreDbContext();
        DbSet<Customer> customers = DbContext.customers;
        DbSet<Location> locations = DbContext.locations;
        DbSet<Order> orders = DbContext.orders;
        DbSet<Product> products = DbContext.products;
        DbSet<Inventory> inventories = DbContext.inventories;

        public bool TestAll()
        {
            // If not all the tests are passed, return false
            if (!TestCreateUser() && !TestAddLocation() && !TestAddInventory() &&
            !TestAddProductToInv() && !TestRemoveProductFromInv() && !TestRemoveInventory() &&
            !TestRemoveLocation() && !TestRemoveUser())
            {
                return false;
            }

            // all tests were passed
            return true;
        }
        public bool TestCreateUser()
        {
            Customer cus = new Customer();
            customers.Add(cus);
            DbContext.SaveChanges();
            if (customers.Any(x => x.ID == cus.ID))
                return true;
            return false;
        }
        public bool TestRemoveUser()
        {
            Customer cus = customers.Where(x => x.Username == "").FirstOrDefault();
            customers.Remove(customers.SingleOrDefault(x => x.ID == cus.ID));
            DbContext.SaveChanges();
            if (!customers.Any(x => x.ID == cus.ID))
            {
                Console.WriteLine("successfully removed user");
                return true;
            }
            return false;
        }
        public bool TestAddLocation()
        {
            Location loc = new Location("Testy", "Testes");
            locations.Add(loc);
            DbContext.SaveChanges();
            if (locations.Any(x => x.LocationID == loc.LocationID))
                return true;
            return false;
        }

        public bool TestAddInventory()
        {
            Location loc = locations.SingleOrDefault(x => x.Name == "Testy");
            Inventory inv = new Inventory();
            inventories.Add(inv);
            DbContext.SaveChanges();
            if (inventories.Any(x => x.InventoryID == inv.InventoryID))
                return true;
            return false;
        }
        public bool TestAddProductToInv()
        {
            Location loc = locations.SingleOrDefault(x => x.Name == "Testy");
            Inventory inv = inventories.SingleOrDefault(x => x.InventoryID == loc.Inventory.InventoryID);
            if (inventories.Any(x => x.InventoryID == inv.InventoryID))
            {
                // create new product
                Product p = new Product("Test", (decimal)5, "Test");
                // add product to inventory
                inv.AddProduct(p, 1);
                // save change to inventory
                DbContext.SaveChanges();
                // check if product is in inventory
                if (inv.ReturnAllProducts(loc).Any(x => x.ProductID == p.ProductID))
                    return true;
            }
            // inventory didn't have the product for some reason
            return false;
        }

        public bool TestRemoveProductFromInv()
        {
            Location loc = locations.SingleOrDefault(x => x.Name == "Testy");
            Inventory inv = inventories.SingleOrDefault(x => x.InventoryID == loc.Inventory.InventoryID);
            if (inventories.Any(x => x.InventoryID == inv.InventoryID))
            {
                // retrieve product
                Product p = products.SingleOrDefault(x => x.Name == "Test");
                // subtract product from inventory
                inv.SubtractProduct(p, 1);
                // save change to inventory
                DbContext.SaveChanges();
                // check if product is in inventory
                if (!inv.ReturnAllProducts(loc).Any(x => x.ProductID == p.ProductID))
                    return true;
            }
            // inventory still had the product for some reason
            return false;
        }

        public bool TestRemoveInventory()
        {
            Location loc = locations.SingleOrDefault(x => x.Name == "Testy");
            Inventory inv = inventories.SingleOrDefault(x => x.InventoryID == loc.Inventory.InventoryID);
            inventories.Remove(inv);
            DbContext.SaveChanges();
            if (!inventories.Any(x => x.InventoryID == inv.InventoryID))
                return true;
            return false;
        }
        public bool TestRemoveLocation()
        {
            Location loc = locations.Where(x => x.Name == "Testy" && x.Address == "Testes").FirstOrDefault();
            locations.Remove(locations.SingleOrDefault(x => x.LocationID == loc.LocationID));
            DbContext.SaveChanges();
            if (!locations.Any(x => x.LocationID == loc.LocationID))
                return true;
            return false;
        }
    }
}