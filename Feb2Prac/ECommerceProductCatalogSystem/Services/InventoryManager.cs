using System;
using System.Security.Permissions;
using ECommerceProductCatalogSystem.Models;

namespace ECommerceProductCatalogSystem.Services
{
    public class InventoryManager
    {
        private readonly List<Product> products = new();
        private int productCounter = 1;
        public void AddProduct(string name, string category, double price, int stock)
        {
            if (price <= 0)
            {
                throw new ArgumentException("Price must be greater than zero.");
            }
            else if (stock < 0)
            {
                throw new ArgumentException("Stock quantity cannot be negative.");
            }
            else
                products.Add(new Product
                {
                    ProductCode = $"P{productCounter++.ToString("D3")}",
                    ProductName = name,
                    Category = category,
                    Price = price,
                    StockQuantity = stock
                });
        }

        public SortedDictionary<string, List<Product>> GroupProductsByCategory()
        {
            return new SortedDictionary<string,List<Product>>(
                products.GroupBy(p=>p.Category).ToDictionary(g=>g.Key,g=>g.ToList())
            );
        }

        public bool UpdateStock(string productCode, int quantity)
        {
            Product? product=products
                .FirstOrDefault(p=>p.ProductCode.Equals(productCode,StringComparison.OrdinalIgnoreCase));

            if(product == null || product.StockQuantity +quantity <0)
            {
                return false;
            }
            product.StockQuantity += quantity;
            return true;
        }

        public List<Product> GetProductsBelowPrice(double maxPrice)
        {
            return products.Where(p=> p.Price < maxPrice).ToList();
        }

        public Dictionary<string, int> GetCategoryStockSummary()
        {
            return products
                .GroupBy(p=> p.Category)
                .ToDictionary(g=> g.Key, g=> g.Sum(p=> p.StockQuantity));
        }
    }
}