using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace P0_DaytonSchuh
{
    public class Inventory
    {
        [Key]
        public int Key { get; set; }
        public Guid InventoryID { get; set; } = Guid.NewGuid(); // FK
        public Guid ProductID { get; set; } // FK to products
        public int Quantity { get; set; } = 0; // quantity of product

        public void SubtractProduct(Product p, int q)
        {
            this.Quantity -= q;
        }
        public Inventory AddProduct(Product p, int q)
        {
            using (StoreDbContext dbContext = new StoreDbContext())
            {
                // get our product
                var productQuery = from prod in dbContext.products
                                   where prod.ProductID == p.ProductID
                                   select prod;

                // look for inventory and product id pair
                var invQuery = from inv in dbContext.inventories
                               where inv.ProductID == p.ProductID
                               select inv;

                // no matching queries
                if (invQuery.Count() == 0)
                {
                    return new Inventory() { InventoryID = InventoryID, ProductID = p.ProductID, Quantity = q };
                }
                // we matched a query
                else
                    //increase the quantity of product at that location
                    foreach (var i in invQuery)
                    {
                        i.Quantity += q;
                    }
                dbContext.SaveChanges();
            }
            return null;
        }
        public List<Product> ReturnAllProducts(Location location)
        {
            // create new list
            List<Product> list = new List<Product>();
            using (StoreDbContext DbContext = new StoreDbContext())
            {
                // retrieve matching inventory instances
                var invList = from inv in DbContext.inventories
                              where inv.InventoryID == location.Inventory.InventoryID && inv.Quantity > 0
                              select inv;

                var prodList = DbContext.products.ToList();
                // for every inventory instance, find the matching product info
                foreach (var inv in invList)
                {
                    foreach (var prod in prodList)
                    {
                        if (inv.ProductID == prod.ProductID)
                        {
                            list.Add(prod);
                        }
                    }
                }
                // add it to the list
            }
            // return the list
            return list;
        }
        public int ReturnQuantityOfItem(Product p)
        {
            using (StoreDbContext DbContext = new StoreDbContext())
            {
                /*TODO: Narrow down lists by using: from, where, select query */
                // retrieve product list
                var prodList = DbContext.products.ToList();
                // retrieve inventory list
                var invList = from inv in DbContext.inventories
                              where inv.InventoryID == InventoryID && inv.Quantity > 0
                              select inv;

                foreach (var inv in invList)
                {
                    foreach (var prod in prodList)
                    {
                        if (inv.ProductID == p.ProductID)
                        {
                            return inv.Quantity;
                        }
                    }
                }
            }
            // we didn't find the product in our inventory
            return -1;
        }
    }
}