using TVShows.Domain;

namespace TVShows.BL;

public interface IGenreBL
{
    IList<Genres> GetAll();

    IList<Genres> CreateGenre(Genres genres);

    IList<Genres> DeleteGenre(int GenreId);
}
