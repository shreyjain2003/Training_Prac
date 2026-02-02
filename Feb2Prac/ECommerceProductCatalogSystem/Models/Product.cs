using System;

namespace ECommerceProductCatalogSystem.Models
{
    public class Product
    {
        public string ProductCode {get; set;}
        public string ProductName {get; set;}
        public string Category {get; set;}
        public double Price {get; set;}
        public int StockQuantity {get; set;}
    }
}