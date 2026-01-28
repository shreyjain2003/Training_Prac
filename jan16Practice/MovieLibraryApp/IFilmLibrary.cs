namespace MovieLibraryApp
{
    public interface IFilmLibrary
    {
        void AddFilm(IFilm film);
        void RemoveFilm(string title);
        List<Film> GetFilms();
        List<Film> SearchFilms(string query);
        int GetTotalFilmCount();
    }
}