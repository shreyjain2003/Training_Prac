using System;
using System.Linq;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ILibrarySystem librarySystem = new LibrarySystem();

            Console.WriteLine("Enter number of books:");
            int bCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= bCount; i++)
            {
                Console.WriteLine($"Enter details for Book {i} with Space(Id Title Author Category Price Quantity):");

                var input = Console.ReadLine().Split(" ");

                IBook book = new Book
                {
                    Id = Convert.ToInt32(input[0]),
                    Title = input[1],
                    Author = input[2],
                    Category = input[3],
                    Price = Convert.ToInt32(input[4])
                };

                int quantity = Convert.ToInt32(input[5]);

                librarySystem.AddBook(book, quantity);
            }

            Console.WriteLine("\nBook Info:");
            var booksInfo = librarySystem.BooksInfo();
            foreach (var (title, quantity, price) in booksInfo.OrderBy(a => a.Item1))
            {
                Console.WriteLine($"Book Name:{title}, Quantity:{quantity}, Price:{price}");
            }

            Console.WriteLine("\nCategory Total Price:");
            var categoryTotalPrice = librarySystem.CategoryTotalPrice();
            foreach (var (category, totalPrice) in categoryTotalPrice.OrderBy(a => a.Item1))
            {
                Console.WriteLine($"Category:{category}, Total Price:{totalPrice}");
            }

            Console.WriteLine("\nCategory And Author With Count:");
            var categoryAndAuthorWithCount = librarySystem.CategoryAndAuthorWithCount();
            foreach (var (category, author, count) in categoryAndAuthorWithCount.OrderBy(a => a.Item1))
            {
                Console.WriteLine($"Category:{category}, Author:{author}, Count:{count}");
            }

            int total = librarySystem.CalculateTotal();
            Console.WriteLine($"\nTotal Price: {total}");
        }
    }
}
