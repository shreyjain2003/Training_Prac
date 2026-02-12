using System;
using System.Collections.Generic;
using System.Linq;
using ParallelAggregation.Models;

namespace ParallelAggregation.Services
{
    public class SalesAggregator
    {
        public Dictionary<string, decimal> GetTotalSalesByRegion(List<Sale> sales)
        {
            return sales
                .AsParallel()
                .GroupBy(s => s.Region)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(s => s.Amount)
                );
        }

        public Dictionary<string, string> GetTopCategoryByRegion(List<Sale> sales)
        {
            return sales
                .AsParallel()
                .GroupBy(s => new { s.Region, s.Category })
                .Select(g => new
                {
                    g.Key.Region,
                    g.Key.Category,
                    Total = g.Sum(x => x.Amount)
                })
                .GroupBy(x => x.Region)
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderByDescending(x => x.Total)
                          .First().Category
                );
        }

        public DateTime GetBestSalesDay(List<Sale> sales)
        {
            return sales
                .AsParallel()
                .GroupBy(s => s.Date.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Total = g.Sum(s => s.Amount)
                })
                .OrderByDescending(x => x.Total)
                .First().Date;
        }
    }
}
