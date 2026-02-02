using System;

namespace LibraryManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LibraryUtility library=new LibraryUtility();

            library.AddBook("1984", "George Orwell", "Fiction", 1949);
            library.AddBook("Animal Farm", "George Orwell", "Fiction", 1945);
            library.AddBook("Sapiens", "Yuval Noah Harari", "Non-Fiction", 2011);
            library.AddBook("Sherlock Holmes", "Arthur Conan Doyle", "Mystery", 1892);

            Console.WriteLine($"Total Books: {library.GetTotalBooks()}");
            Console.WriteLine("Books grouped by Genre: ");
            var grouped=library.GroupBooksByGenre();

            foreach( var genre in grouped)
            {
                Console.WriteLine($"\n{genre.Key}: ");
                foreach(var book in genre.Value)
                {
                    Console.WriteLine($"- {book.Title} by {book.Author} ({book.PublicationYear})");
                }
            }

            Console.WriteLine("\nBooks by George Orwell: ");
            var orwellBooks=library.GetBooksByAuthor("George Orwell");
            foreach(var book in orwellBooks)
            {
                Console.WriteLine($"- {book.Title} ({book.PublicationYear})");
            }

        }
    }
}