using TVShows.Domain;

namespace TVShows.BL;

public interface IGenreBL
{
    IList<Genre> GetAll();

    Genre CreateGenre(Genre genres);

    Genre UpdateGenre(Genre genres);

    bool DeleteGenre(int genreId);

    Genre GetGenreById(int genreId);

}
