using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStockApp
{
    class Program
    {
        public static List<Movie> MovieList = new List<Movie>();

        /// <summary>
        /// Adds movie to MovieList.
        /// </summary>
        public void AddMovie(string movieDetails)
        {
            string[] data = movieDetails.Split(',');

            MovieList.Add(new Movie
            {
                Title = data[0],
                Artist = data[1],
                Genre = data[2],
                Ratings = int.Parse(data[3])
            });
        }

        /// <summary>
        /// Views movies by genre.
        /// </summary>
        public List<Movie> ViewMoviesByGenre(string genre)
        {
            return MovieList.Where(m => m.Genre.Equals(genre)).ToList();
        }

        /// <summary>
        /// Sorts movies by rating.
        /// </summary>
        public List<Movie> ViewMoviesByRatings()
        {
            return MovieList.OrderBy(m => m.Ratings).ToList();
        }

        static void Main()
        {
            Program p = new Program();
            p.AddMovie("Avatar,James Cameron,SciFi,9");
            p.AddMovie("Titanic,James Cameron,Romance,8");

            var movies = p.ViewMoviesByGenre("SciFi");
            if (movies.Count == 0)
                Console.WriteLine("No Movies found in genre SciFi");

            foreach (var m in p.ViewMoviesByRatings())
                Console.WriteLine(m.Title + " - " + m.Ratings);
        }
    }
}
