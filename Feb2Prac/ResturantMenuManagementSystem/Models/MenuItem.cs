using System;

namespace ResturantMenuManagementSystem.Models
{
    public class MenuItem
    {
        // - string ItemName
        // - string Category (Appetizer/Main Course/Dessert)
        // - double Price
        // - bool IsVegetarian

        public string ItemName {get; set;}
        public string Category {get; set;}
        public double Price {get; set;}
        public bool IsVegetarian {get; set;}

    }
}