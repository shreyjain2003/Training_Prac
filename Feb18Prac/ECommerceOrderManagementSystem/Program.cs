using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceOrderManagementSystem
{
    #region Custom Exceptions

    public class OutOfStockException : Exception
    {
        public OutOfStockException(string message) : base(message) { }
    }

    public class OrderAlreadyShippedException : Exception
    {
        public OrderAlreadyShippedException(string message) : base(message) { }
    }

    public class CustomerBlacklistedException : Exception
    {
        public CustomerBlacklistedException(string message) : base(message) { }
    }

    #endregion

    #region Entities

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }  // FIXED (decimal for money)
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"{Id} | {Name} | ₹{Price} | Stock: {Stock}";
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsBlacklisted { get; set; }

        public override string ToString()
        {
            return $"{Id} | {Name} | Blacklisted: {IsBlacklisted}";
        }
    }

    public enum OrderStatus
    {
        Pending,
        Shipped,
        Cancelled
    }

    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice()
        {
            return Product.Price * Quantity;
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public decimal TotalAmount()
        {
            return Items.Sum(i => i.TotalPrice());
        }

        public override string ToString()
        {
            return $"OrderId: {OrderId} | Customer: {Customer.Name} | ₹{TotalAmount()} | Status: {Status}";
        }
    }

    #endregion

    #region Discount Strategy (Strategy Pattern)

    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal amount);
    }

    public class PercentageDiscount : IDiscountStrategy
    {
        private decimal percentage;

        public PercentageDiscount(decimal percent)
        {
            percentage = percent;
        }

        public decimal ApplyDiscount(decimal amount)
        {
            return amount - (amount * percentage / 100);
        }
    }

    public class FlatDiscount : IDiscountStrategy
    {
        private decimal flatAmount;

        public FlatDiscount(decimal amount)
        {
            flatAmount = amount;
        }

        public decimal ApplyDiscount(decimal amount)
        {
            return amount - flatAmount;
        }
    }

    public class FestivalDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal amount)
        {
            return amount - (amount * 0.20m); // 20% discount
        }
    }

    #endregion

    #region Service Layer

    public class ECommerceService
    {
        public List<Product> Products = new List<Product>();
        public List<Customer> Customers = new List<Customer>();
        public List<Order> Orders = new List<Order>();

        // Dictionary for fast lookup
        public Dictionary<int, Product> ProductDictionary = new Dictionary<int, Product>();

        public void PlaceOrder(int customerId, Dictionary<int, int> productQuantities, IDiscountStrategy discountStrategy)
        {
            var customer = Customers.FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
                throw new Exception("Customer not found.");

            if (customer.IsBlacklisted)
                throw new CustomerBlacklistedException("Customer is blacklisted.");

            Order order = new Order
            {
                OrderId = Orders.Count + 1,
                Customer = customer,
                OrderDate = DateTime.Now,
                Status = OrderStatus.Pending
            };

            foreach (var item in productQuantities)
            {
                if (!ProductDictionary.ContainsKey(item.Key))
                    throw new Exception("Product not found.");

                var product = ProductDictionary[item.Key];

                if (product.Stock < item.Value)
                    throw new OutOfStockException($"{product.Name} is out of stock.");

                product.Stock -= item.Value;

                order.Items.Add(new OrderItem
                {
                    Product = product,
                    Quantity = item.Value
                });
            }

            decimal total = order.TotalAmount();
            decimal discountedTotal = discountStrategy.ApplyDiscount(total);

            Console.WriteLine($"Original Amount: ₹{total}");
            Console.WriteLine($"After Discount: ₹{discountedTotal}");

            Orders.Add(order);
        }

        public void CancelOrder(int orderId)
        {
            var order = Orders.FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
                throw new Exception("Order not found.");

            if (order.Status == OrderStatus.Shipped)
                throw new OrderAlreadyShippedException("Cannot cancel shipped order.");

            order.Status = OrderStatus.Cancelled;

            Console.WriteLine("Order cancelled successfully.");
        }

        public void RunLinqQueries()
        {
            Console.WriteLine("\nOrders in last 7 days:");
            var recentOrders = Orders.Where(o => o.OrderDate >= DateTime.Now.AddDays(-7));
            foreach (var o in recentOrders)
                Console.WriteLine(o);

            Console.WriteLine("\nTotal Revenue:");
            Console.WriteLine(Orders.Sum(o => o.TotalAmount()));

            Console.WriteLine("\nMost Sold Product:");
            var mostSold = Orders
                .SelectMany(o => o.Items)
                .GroupBy(i => i.Product.Name)
                .OrderByDescending(g => g.Sum(i => i.Quantity))
                .FirstOrDefault();

            if (mostSold != null)
                Console.WriteLine(mostSold.Key);

            Console.WriteLine("\nTop 5 Customers by Spending:");
            var topCustomers = Orders
                .GroupBy(o => o.Customer.Name)
                .Select(g => new { Name = g.Key, Total = g.Sum(o => o.TotalAmount()) })
                .OrderByDescending(x => x.Total)
                .Take(5);

            foreach (var c in topCustomers)
                Console.WriteLine($"{c.Name} - ₹{c.Total}");

            Console.WriteLine("\nProducts with stock < 10:");
            var lowStock = Products.Where(p => p.Stock < 10);
            foreach (var p in lowStock)
                Console.WriteLine(p);
        }
    }

    #endregion

    class Program
    {
        static void Main()
        {
            ECommerceService service = new ECommerceService();

            // Sample Products
            service.Products.Add(new Product { Id = 1, Name = "Laptop", Price = 60000m, Stock = 20 });
            service.Products.Add(new Product { Id = 2, Name = "Phone", Price = 30000m, Stock = 15 });
            service.Products.Add(new Product { Id = 3, Name = "Headphones", Price = 5000m, Stock = 5 });

            // Fill dictionary
            foreach (var p in service.Products)
                service.ProductDictionary[p.Id] = p;

            // Sample Customers
            service.Customers.Add(new Customer { Id = 1, Name = "Rahul", IsBlacklisted = false });
            service.Customers.Add(new Customer { Id = 2, Name = "Riya", IsBlacklisted = false });
            service.Customers.Add(new Customer { Id = 3, Name = "Amit", IsBlacklisted = true });

            while (true)
            {
                Console.WriteLine("\n===== E-COMMERCE SYSTEM =====");
                Console.WriteLine("1. Place Order");
                Console.WriteLine("2. Cancel Order");
                Console.WriteLine("3. Run LINQ Queries");
                Console.WriteLine("0. Exit");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Customer Id: ");
                            int custId = int.Parse(Console.ReadLine());

                            Dictionary<int, int> items = new Dictionary<int, int>();
                            Console.Write("Product Id: ");
                            int pid = int.Parse(Console.ReadLine());
                            Console.Write("Quantity: ");
                            int qty = int.Parse(Console.ReadLine());
                            items.Add(pid, qty);

                            IDiscountStrategy discount = new FestivalDiscount();
                            service.PlaceOrder(custId, items, discount);
                            break;

                        case 2:
                            Console.Write("Order Id: ");
                            int orderId = int.Parse(Console.ReadLine());
                            service.CancelOrder(orderId);
                            break;

                        case 3:
                            service.RunLinqQueries();
                            break;

                        case 0:
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
