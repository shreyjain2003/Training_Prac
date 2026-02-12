using System;
using Q08_AdvancedCache.Services;

namespace Q08_AdvancedCache
{
    class Program
    {
        static void Main()
        {
            var cache = new AdvancedCache<string, string>(2);

            cache.Set("A", "Apple", 5);
            cache.Set("B", "Banana", 5);

            Console.WriteLine(cache.Get("A")); // Access A (recent)

            cache.Set("C", "Cherry", 5); // Evicts B

            Console.WriteLine(cache.Get("B")); // null
            Console.WriteLine(cache.Get("A")); // Apple
            Console.WriteLine(cache.Get("C")); // Cherry
        }
    }
}
