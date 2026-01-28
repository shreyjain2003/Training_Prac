using System.Collections.Generic;
using System.Linq;

namespace MovieLibraryApp
{
    public class FilmLibrary : IFilmLibrary
    {
        // ✅ As per question: List<Film>
        private List<Film> _films = new List<Film>();

        public void AddFilm(IFilm film)
        {
            // Safe cast because Film implements IFilm
            if (film is Film f)
            {
                _films.Add(f);
            }
        }

        public void RemoveFilm(string title)
        {
            var film = _films.FirstOrDefault(f => f.Title == title);
            if (film != null)
            {
                _films.Remove(film);
            }
        }

        public List<Film> GetFilms()
        {
            return _films;
        }

        public List<Film> SearchFilms(string query)
        {
            return _films
                .Where(f =>
                    f.Title.Contains(query) ||
                    f.Director.Contains(query))
                .ToList();
        }

        public int GetTotalFilmCount()
        {
            return _films.Count;
        }
    }
}
