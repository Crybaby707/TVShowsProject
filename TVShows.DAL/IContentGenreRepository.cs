using TVShows.Domain;

namespace TVShows.DAL
{
    public interface IContentGenreRepository
    {

        IList<ContentGenre> GetAll();

        ContentGenre CreateContentGenre(ContentGenre contentGenres);

        ContentGenre UpdateContentGenre(ContentGenre contentGenres);

        bool DeleteContentGenre(int contentGenreID);

        ContentGenre GetContentGenreById(int contentGenreID);

    }
}
