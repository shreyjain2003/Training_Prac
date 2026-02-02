using System;
using ResturantMenuManagementSystem.Models;

namespace ResturantMenuManagementSystem.Services
{
    public class MenuManager
    {
        private readonly List<MenuItem> menuItems=new();
        public void AddMenuItem(string name, string category, double price, bool isVeg)
        {
            if(price > 0)
            {
                menuItems.Add(new MenuItem
                {
                    ItemName=name,
                    Category=category,
                    Price=price,
                    IsVegetarian=isVeg
                });
            }
            else
            {
                throw new ArgumentException("Price must be greater than zero.");
            }
        }

        public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
        {
            return new Dictionary<string,List<MenuItem>> (
                menuItems.GroupBy(i=> i.Category).ToDictionary(g=> g.Key,g=>g.ToList())
            );
        }

        public List<MenuItem> GetVegetarianItems()
        {
            return menuItems.Where(i=> i.IsVegetarian).ToList();
        }

        public double CalculateAveragePriceByCategory(string category)
        {
            var items = menuItems
                .Where(i => i.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!items.Any())
                return 0;

            return items.Average(i => i.Price);
        }

    }
}