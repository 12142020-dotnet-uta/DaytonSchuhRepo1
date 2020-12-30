using System.Collections.Generic;
using P0_DaytonSchuh1;

namespace P0_Main
{
    public interface RepoInterface
    {
        List<Product> GetProducts();
        List<Location> GetLocations();
        List<Order> GetOrders();
        List<OrderLine> GetOrderLines();
        List<Customer> GetCustomers();
        List<LocationLine> GetLocationLines();
    }
}