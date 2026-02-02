using System;
using ResturantMenuManagementSystem.Services;

namespace ResturantMenuManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MenuManager menu = new MenuManager();

            // Add menu items
            menu.AddMenuItem("Spring Rolls", "Appetizer", 180, true);
            menu.AddMenuItem("Chicken Tikka", "Appetizer", 250, false);
            menu.AddMenuItem("Paneer Butter Masala", "Main Course", 320, true);
            menu.AddMenuItem("Chicken Biryani", "Main Course", 400, false);
            menu.AddMenuItem("Gulab Jamun", "Dessert", 120, true);

            // Group items by category
            Console.WriteLine("Menu Grouped By Category:");
            var groupedMenu = menu.GroupItemsByCategory();

            foreach (var category in groupedMenu)
            {
                Console.WriteLine($"\n{category.Key}:");
                foreach (var item in category.Value)
                {
                    Console.WriteLine(
                        $"- {item.ItemName} | ₹{item.Price} | {(item.IsVegetarian ? "Veg" : "Non-Veg")}"
                    );
                }
            }

            // Vegetarian menu
            Console.WriteLine("\nVegetarian Items:");
            var vegItems = menu.GetVegetarianItems();
            foreach (var item in vegItems)
            {
                Console.WriteLine($"- {item.ItemName}");
            }

            // Average price
            Console.WriteLine("\nAverage Price of Main Course:");
            Console.WriteLine($"₹{menu.CalculateAveragePriceByCategory("Main Course")}");
        }
    }
}