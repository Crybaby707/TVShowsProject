using TVShows.Domain;

namespace TVShows.DAL;
public interface IGenreRepository
{
    IList<Genre> GetAll();

    Genre CreateGenre(Genre genres);

    Genre UpdateGenre(Genre genres);

    bool DeleteGenre(int genreId);

    Genre GetGenreById(int genreId);
}