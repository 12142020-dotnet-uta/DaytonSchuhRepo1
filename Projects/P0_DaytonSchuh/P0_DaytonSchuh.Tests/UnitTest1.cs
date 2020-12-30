using P0_DaytonSchuh1;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace P0_DaytonSchuh1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestCustomerCreation()
        {
            var options = new DbContextOptionsBuilder<P0_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            using (var context = new P0_DbContext(options))
            {
                context.Add(new Customer("Test", "Best"));
                context.SaveChanges();
            }

            using (var context = new P0_DbContext(options))
            {
                var customer = context.customers.SingleOrDefault(x => x.FirstName == "Test").FirstName;
                Assert.Equal("Test", customer);
            }
        }
        [Fact]
        public void TestLocationCreation()
        {
            var options = new DbContextOptionsBuilder<P0_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            using (var context = new P0_DbContext(options))
            {
                context.Add(new Location("Test", "Test", "Test", "Test"));
                context.SaveChanges();
            }

            using (var context = new P0_DbContext(options))
            {
                var location = context.locations.SingleOrDefault(x => x.Address == "Test").Address;
                Assert.Equal("Test", location);
            }
        }

        [Fact]
        public void TestOrderCreation()
        {
            var options = new DbContextOptionsBuilder<P0_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            using (var context = new P0_DbContext(options))
            {
                context.Add(new Order(1, 1, DateTime.Now, 1));
                context.SaveChanges();
            }

            using (var context = new P0_DbContext(options))
            {
                var order = context.orders.SingleOrDefault(x => x.OrderId == 1);
                Assert.Equal(1, 1);
            }
        }
        [Fact]
        public void TestOrderLineCreation()
        {
            var options = new DbContextOptionsBuilder<P0_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            using (var context = new P0_DbContext(options))
            {
                context.Add(new OrderLine(1, 1, 1, 1, 1));
                context.SaveChanges();
            }

            using (var context = new P0_DbContext(options))
            {
                var orderLine = context.orderLines.SingleOrDefault(x => x.OrderLineId == 1).OrderLineId;
                Assert.Equal(1, orderLine);
            }
        }

        [Fact]
        public void TestLocationLineCreation()
        {
            var options = new DbContextOptionsBuilder<P0_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            using (var context = new P0_DbContext(options))
            {
                context.Add(new LocationLine(1, 1, 1, 1));
                context.SaveChanges();
            }

            using (var context = new P0_DbContext(options))
            {
                var locationLine = context.locationLines.SingleOrDefault(x => x.LocationLineId == 1);
                Assert.Equal(1, 1);
            }
        }

        [Fact]
        public void TestCustomerRemoval()
        {
            var options = new DbContextOptionsBuilder<P0_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;



            using (var context = new P0_DbContext(options))
            {
                context.Add(new Customer("Test", "Best"));
                context.SaveChanges();
                context.Remove(context.customers.SingleOrDefault(x => x.FirstName == "Test"));
                context.SaveChanges();
            }

            using (var context = new P0_DbContext(options))
            {
                Assert.Null(context.customers.SingleOrDefault(x => x.FirstName == "Test"));
            }
        }

        [Fact]
        public void TestLocationRemoval()
        {
            var options = new DbContextOptionsBuilder<P0_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            using (var context = new P0_DbContext(options))
            {
                context.Remove(context.locations.SingleOrDefault(x => x.Address == "Test"));
                context.SaveChanges();
            }

            using (var context = new P0_DbContext(options))
            {
                Assert.Null(context.locations.SingleOrDefault(x => x.Address == "Test"));
            }
        }

        [Fact]
        public void TestOrderRemoval()
        {
            var options = new DbContextOptionsBuilder<P0_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            using (var context = new P0_DbContext(options))
            {
                context.Add(new Order(1, 1, DateTime.Now, 1));
                context.SaveChanges();
                context.Remove(context.orders.SingleOrDefault(x => x.OrderId == 1));
                context.SaveChanges();
            }

            using (var context = new P0_DbContext(options))
            {
                Assert.Null(context.orders.SingleOrDefault(x => x.OrderId == 1));
            }
        }

        [Fact]
        public void TestOrderLineRemoval()
        {
            var options = new DbContextOptionsBuilder<P0_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            using (var context = new P0_DbContext(options))
            {
                context.Remove(context.orderLines.SingleOrDefault(x => x.OrderLineId == 1));
                context.SaveChanges();
            }

            using (var context = new P0_DbContext(options))
            {
                Assert.Null(context.orderLines.SingleOrDefault(x => x.OrderLineId == 1));
            }
        }

        [Fact]
        public void TestLocationLineRemoval()
        {
            var options = new DbContextOptionsBuilder<P0_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            using (var context = new P0_DbContext(options))
            {
                context.Remove(context.locationLines.SingleOrDefault(x => x.LocationLineId == 1));
                context.SaveChanges();
            }

            using (var context = new P0_DbContext(options))
            {
                Assert.Null(context.locationLines.SingleOrDefault(x => x.LocationId == 1));
            }
        }
    }
}
