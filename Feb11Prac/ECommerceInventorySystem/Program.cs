using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceInventorySystem
{
    // Base Product Interface
    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; set; }
        Category Category { get; }
    }

    public enum Category { Electronics, Clothing, Books, Groceries }

    // ================= GENERIC REPOSITORY =================
    public class ProductRepository<T> where T : class, IProduct
    {
        private List<T> _products = new List<T>();

        public void AddProduct(T product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Product name cannot be empty");

            if (product.Price <= 0)
                throw new ArgumentException("Price must be positive");

            if (_products.Any(p => p.Id == product.Id))
                throw new InvalidOperationException("Product ID must be unique");

            _products.Add(product);
        }

        public IEnumerable<T> FindProducts(Func<T, bool> predicate)
        {
            return _products.Where(predicate);
        }

        public decimal CalculateTotalValue()
        {
            return _products.Sum(p => p.Price);
        }

        public List<T> GetAll() => _products;
    }

    // ================= ELECTRONIC PRODUCT =================
    public class ElectronicProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category => Category.Electronics;
        public int WarrantyMonths { get; set; }
        public string Brand { get; set; }
    }

    // ================= DISCOUNT WRAPPER =================
    public class DiscountedProduct<T> where T : IProduct
    {
        private T _product;
        private decimal _discountPercentage;

        public DiscountedProduct(T product, decimal discountPercentage)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (discountPercentage < 0 || discountPercentage > 100)
                throw new ArgumentException("Discount must be between 0 and 100");

            _product = product;
            _discountPercentage = discountPercentage;
        }

        public decimal DiscountedPrice =>
            _product.Price * (1 - _discountPercentage / 100);

        public override string ToString()
        {
            return $"{_product.Name} | Original: {_product.Price:C} | " +
                   $"Discount: {_discountPercentage}% | Final: {DiscountedPrice:C}";
        }
    }

    // ================= INVENTORY MANAGER =================
    public class InventoryManager
    {
        public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
        {
            Console.WriteLine("\nAll Products:");
            foreach (var p in products)
                Console.WriteLine($"{p.Name} - {p.Price:C}");

            var mostExpensive = products.OrderByDescending(p => p.Price).FirstOrDefault();
            Console.WriteLine($"\nMost Expensive: {mostExpensive?.Name}");

            Console.WriteLine("\nGrouped By Category:");
            var grouped = products.GroupBy(p => p.Category);
            foreach (var group in grouped)
            {
                Console.WriteLine($"\n{group.Key}:");
                foreach (var item in group)
                    Console.WriteLine($"  {item.Name}");
            }

            Console.WriteLine("\nApplying 10% discount to Electronics over $500:");
            foreach (var p in products.Where(p => p.Category == Category.Electronics && p.Price > 500))
            {
                var discounted = new DiscountedProduct<IProduct>(p, 10);
                Console.WriteLine(discounted);
            }
        }

        public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
            where T : IProduct
        {
            foreach (var product in products)
            {
                try
                {
                    product.Price = priceAdjuster(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating {product.Name}: {ex.Message}");
                }
            }
        }
    }

    // ================= PROGRAM =================
    public class Program
    {
        static void Main()
        {
            var repo = new ProductRepository<ElectronicProduct>();

            try
            {
                repo.AddProduct(new ElectronicProduct
                {
                    Id = 1,
                    Name = "iPhone 15",
                    Price = 1200,
                    Brand = "Apple",
                    WarrantyMonths = 12
                });

                repo.AddProduct(new ElectronicProduct
                {
                    Id = 2,
                    Name = "Samsung TV",
                    Price = 800,
                    Brand = "Samsung",
                    WarrantyMonths = 24
                });

                repo.AddProduct(new ElectronicProduct
                {
                    Id = 3,
                    Name = "Budget Earphones",
                    Price = 50,
                    Brand = "Boat",
                    WarrantyMonths = 6
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nFind Products By Brand = Samsung:");
            var samsungProducts = repo.FindProducts(p => p.Brand == "Samsung");
            foreach (var p in samsungProducts)
                Console.WriteLine(p.Name);

            Console.WriteLine($"\nTotal Value Before Update: {repo.CalculateTotalValue():C}");

            var manager = new InventoryManager();

            manager.ProcessProducts(repo.GetAll());

            manager.UpdatePrices(repo.GetAll(), p => p.Price * 1.05m);

            Console.WriteLine($"\nTotal Value After 5% Increase: {repo.CalculateTotalValue():C}");
        }
    }
}
