using System;

namespace MovieLibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IFilmLibrary library = new FilmLibrary();

            library.AddFilm(new Film
            {
                Title = "Inception",
                Director = "Christopher Nolan",
                Year = 2010
            });

            library.AddFilm(new Film
            {
                Title = "Interstellar",
                Director = "Christopher Nolan",
                Year = 2014
            });

            Console.WriteLine("Total Films: " + library.GetTotalFilmCount());

            Console.WriteLine("Search Results:");
            var results = library.SearchFilms("Nolan");
            foreach (var film in results)
            {
                Console.WriteLine($"{film.Title} ({film.Year})");
            }
        }
    }
}
