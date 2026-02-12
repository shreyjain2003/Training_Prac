using System;
using CommandPattern.Commands;
using CommandPattern.Models;
using CommandPattern.Services;

namespace CommandPattern
{
    class Program
    {
        static void Main()
        {
            var cart = new Cart();
            var manager = new CommandManager();

            manager.ExecuteCommand(new AddItemCommand(cart, "Laptop"));
            manager.ExecuteCommand(new AddItemCommand(cart, "Mouse"));
            manager.ExecuteCommand(new ApplyDiscountCommand(cart, 0.1m));

            Console.WriteLine($"Total after discount: {cart.GetTotal()}");

            manager.Undo(); // Undo discount
            Console.WriteLine($"Total after undo discount: {cart.GetTotal()}");

            manager.Redo(); // Redo discount
            Console.WriteLine($"Total after redo discount: {cart.GetTotal()}");
        }
    }
}
