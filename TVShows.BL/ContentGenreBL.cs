using TVShows.DAL;
using TVShows.Domain;

namespace TVShows.BL;

public class ContentGenreBL : IContentGenreBL
{
    private readonly IContentGenreRepository _contentGenreRepository;

    public ContentGenreBL(IContentGenreRepository contentGenreRepository)
    {
        _contentGenreRepository = contentGenreRepository;
    }

    public ContentGenre CreateContentGenre(ContentGenre contentGenres)
    {
        return _contentGenreRepository.CreateContentGenre(contentGenres);
    }

    public bool DeleteContentGenre(int contentGenreID)
    {
        return _contentGenreRepository.DeleteContentGenre(contentGenreID);
    }

    public IList<ContentGenre> GetAll()
    {
        return _contentGenreRepository.GetAll();
    }

    public ContentGenre GetContentGenreById(int contentGenreId)
    {
        return _contentGenreRepository.GetContentGenreById(contentGenreId);
    }

    public ContentGenre UpdateContentGenre(ContentGenre contentGenres)
    {
        return _contentGenreRepository.UpdateContentGenre(contentGenres);
    }
}
