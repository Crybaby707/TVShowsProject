using TVShows.Domain;

namespace TVShows.DAL;
public interface IGenreRepository
{
    IList<Genres> GetAll();

    IList<Genres> CreateGenre(Genres genres);

    IList<Genres> DeleteGenre(int GenreId);
}