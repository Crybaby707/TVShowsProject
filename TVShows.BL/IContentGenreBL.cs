using TVShows.Domain;

namespace TVShows.BL;
public interface IContentGenreBL
{
    IList<ContentGenre> GetAll();

    ContentGenre CreateContentGenre(ContentGenre contentGenres);

    ContentGenre UpdateContentGenre(ContentGenre contentGenres);

    bool DeleteContentGenre(int contentGenreID);

    ContentGenre GetContentGenreById(int contentGenreID);
}

