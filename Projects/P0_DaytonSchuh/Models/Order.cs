using System;
using System.Collections.Generic;

namespace P0_DaytonSchuh
{
    public class Order
    {
        private string location;
        private Guid customerID;
        //private DateTime orderPlaced;
        private List<Product> order;
        // if the list of products contains any unordinarily large quantities, reject order
        // optional: special deals
    }
}