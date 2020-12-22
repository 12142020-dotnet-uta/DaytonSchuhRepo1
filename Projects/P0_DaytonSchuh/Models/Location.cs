using System.Collections.Generic;

namespace P0_DaytonSchuh
{
    public class Location
    {
        public List<Product> inventory;
        // inventory decreases when orders are accepted
        // reject orders that current inventory cannot satisfy
        // optional: for at least one product, more than one inventory item
        // decreases when ordering that product
    }
}