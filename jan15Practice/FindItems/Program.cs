using System;
using System.Collections.Generic;
using System.Linq;

namespace FindItems
{
    class Program
    {
        /// <summary>
        /// Stores item name and sold count.
        /// </summary>
        public static SortedDictionary<string, long> itemDetails =
            new SortedDictionary<string, long>();

        /// <summary>
        /// Finds item details based on sold count.
        /// </summary>
        public static SortedDictionary<string, long> FindItemDetails(long soldCount)
        {
            var result = new SortedDictionary<string, long>();

            foreach (var item in itemDetails)
            {
                if (item.Value == soldCount)
                    result.Add(item.Key, item.Value);
            }

            return result;
        }

        /// <summary>
        /// Finds minimum and maximum sold items.
        /// </summary>
        public static List<string> FindMinAndMaxSoldItems()
        {
            long min = itemDetails.Values.Min();
            long max = itemDetails.Values.Max();

            string minItem = itemDetails.First(x => x.Value == min).Key;
            string maxItem = itemDetails.First(x => x.Value == max).Key;

            return new List<string> { minItem, maxItem };
        }

        /// <summary>
        /// Sorts items by sold count.
        /// </summary>
        public static Dictionary<string, long> SortByCount()
        {
            return itemDetails.OrderBy(x => x.Value)
                              .ToDictionary(x => x.Key, x => x.Value);
        }

        static void Main()
        {
            itemDetails.Add("Pen", 100);
            itemDetails.Add("Book", 300);
            itemDetails.Add("Pencil", 50);

            var found = FindItemDetails(300);
            if (found.Count == 0)
                Console.WriteLine("Invalid sold count");

            var minMax = FindMinAndMaxSoldItems();
            Console.WriteLine($"Min Sold: {minMax[0]}");
            Console.WriteLine($"Max Sold: {minMax[1]}");

            foreach (var item in SortByCount())
                Console.WriteLine($"{item.Key} - {item.Value}");
        }
    }
}
