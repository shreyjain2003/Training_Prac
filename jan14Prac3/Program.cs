using System;
using System.Collections.Generic;

namespace jan14Prac3
{
class Program
{
    static void Main()
    {
        // Generic class with int
        GenericUtility<int> intUtility = new GenericUtility<int>();
        intUtility.AddItem(10);
        intUtility.AddItem(20);
        intUtility.DisplayAll();

        // Generic class with string
        GenericUtility<string> stringUtility = new GenericUtility<string>();
        stringUtility.AddItem("Apple");
        stringUtility.AddItem("Banana");
        stringUtility.DisplayAll();

        // Using second generic method
        List<string> names = new List<string> { "Arun", "Divya", "Ravi" };

        string? result = stringUtility.FindFirstOrNull(
            names,
            n => n.StartsWith("D")
        );

        Console.WriteLine($"\nFirst matching name: {result}");
    }
}
}