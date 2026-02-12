using System;
using System.Collections.Generic;
using ParallelAggregation.Models;
using ParallelAggregation.Services;

namespace ParallelAggregation
{
    class Program
    {
        static void Main()
        {
            var sales = new List<Sale>
            {
                new Sale { Region="North", Category="Electronics", Amount=1000, Date=new DateTime(2024,2,1) },
                new Sale { Region="North", Category="Electronics", Amount=2000, Date=new DateTime(2024,2,1) },
                new Sale { Region="North", Category="Clothing", Amount=500, Date=new DateTime(2024,2,2) },
                new Sale { Region="South", Category="Electronics", Amount=3000, Date=new DateTime(2024,2,2) },
                new Sale { Region="South", Category="Clothing", Amount=4000, Date=new DateTime(2024,2,3) }
            };

            var aggregator = new SalesAggregator();

            var totalByRegion = aggregator.GetTotalSalesByRegion(sales);
            var topCategory = aggregator.GetTopCategoryByRegion(sales);
            var bestDay = aggregator.GetBestSalesDay(sales);

            Console.WriteLine("Total Sales by Region:");
            foreach (var item in totalByRegion.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Console.WriteLine("\nTop Category by Region:");
            foreach (var item in topCategory.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Console.WriteLine($"\nBest Sales Day: {bestDay:yyyy-MM-dd}");
        }
    }
}
