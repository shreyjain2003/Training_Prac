using System.Collections.Generic;
using System.Linq;

namespace Q10_CommandPattern.Models
{
    public class Cart
    {
        public List<string> Items { get; } = new();
        public decimal Discount { get; private set; }

        public void AddItem(string item) => Items.Add(item);
        public void RemoveItem(string item) => Items.Remove(item);

        public void ApplyDiscount(decimal discount)
        {
            Discount = discount;
        }

        public decimal GetTotal()
        {
            return Items.Count * 100 * (1 - Discount);
        }
    }
}
