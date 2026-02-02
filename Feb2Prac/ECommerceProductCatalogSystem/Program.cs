using System;
using ECommerceProductCatalogSystem.Services;

namespace EcommerceProductCatalogSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InventoryManager inventory =new InventoryManager();

            inventory.AddProduct("Laptop", "Electronics", 75000, 10);
            inventory.AddProduct("Headphones", "Electronics", 2500, 30);
            inventory.AddProduct("T-Shirt", "Clothing", 800, 50);
            inventory.AddProduct("Jeans", "Clothing", 2200, 25);
            inventory.AddProduct("C# Programming Book", "Books", 1200, 40);

            var grouped=inventory.GroupProductsByCategory();
            foreach(var category in grouped)
            {
                Console.WriteLine($"Category: {category.Key}");
                foreach(var product in category.Value)
                {
                    Console.WriteLine($" - {product.ProductName}, Price: {product.Price}, Stock: {product.StockQuantity}");
                }
            }

            //3.	Update stock after sales
            inventory.UpdateStock("P001",2);
            inventory.UpdateStock("P003",-5);

            //4.	Find products under budget
            var budgetProducts=inventory.GetProductsBelowPrice(3000);
            Console.WriteLine("\nProducts below price 3000:");
            foreach(var product in budgetProducts)
            {
                Console.WriteLine($" - {product.ProductName}, Price: {product.Price}, Stock: {product.StockQuantity}");
            }

            //5.	Show inventory summary
            var stockSummary=inventory.GetCategoryStockSummary();
            Console.WriteLine("\nInventory Summary:");
            foreach(var entry in stockSummary)
            {
                Console.WriteLine($"Category: {entry.Key}, Total Stock: {entry.Value}");
            }
        }
    }
}