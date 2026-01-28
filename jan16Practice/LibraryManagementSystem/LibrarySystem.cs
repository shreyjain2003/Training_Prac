using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Implements library management logic.
    /// </summary>
    public class LibrarySystem : ILibrarySystem
    {
        // Internal storage: Book + Quantity
        private List<(IBook book, int quantity)> books
            = new List<(IBook, int)>();

        public void AddBook(IBook book, int quantity)
        {
            var existing = books.FirstOrDefault(b => b.book.Id == book.Id);

            if (existing.book != null)
            {
                books.Remove(existing);
                books.Add((existing.book, existing.quantity + quantity));
            }
            else
            {
                books.Add((book, quantity));
            }
        }

        public void RemoveBook(IBook book, int quantity)
        {
            var existing = books.FirstOrDefault(b => b.book.Id == book.Id);

            if (existing.book != null)
            {
                books.Remove(existing);

                int remaining = existing.quantity - quantity;
                if (remaining > 0)
                {
                    books.Add((existing.book, remaining));
                }
            }
        }

        public int CalculateTotal()
        {
            return books.Sum(b => b.book.Price * b.quantity);
        }

        public List<(string, int)> CategoryTotalPrice()
        {
            return books
                .GroupBy(b => b.book.Category)
                .Select(g =>
                    (g.Key, g.Sum(x => x.book.Price * x.quantity)))
                .ToList();
        }

        public List<(string, int, int)> BooksInfo()
        {
            return books
                .Select(b =>
                    (b.book.Title, b.quantity, b.book.Price * b.quantity))
                .ToList();
        }

        public List<(string, string, int)> CategoryAndAuthorWithCount()
        {
            return books
                .GroupBy(b => new { b.book.Category, b.book.Author })
                .Select(g =>
                    (g.Key.Category, g.Key.Author, g.Count()))
                .ToList();
        }
    }
}
