using TVShows.DAL;
using TVShows.Domain;

namespace TVShows.BL;

public class GenreBL : IGenreBL
{
    private readonly IGenreRepository _genreRepository;

    public GenreBL(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public Genre CreateGenre(Genre genres)
    {
        return _genreRepository.CreateGenre(genres);
    }

    public IList<Genre> GetAll()
    {
        return _genreRepository.GetAll();
    }
    
    public Genre GetGenreById(int genreId)
    {
        return _genreRepository.GetGenreById(genreId);
    }


    public bool DeleteGenre(int genreId)
    {
        return _genreRepository.DeleteGenre(genreId);
    }

    public Genre UpdateGenre(Genre genres)
    {
        return _genreRepository.UpdateGenre(genres);
    }
}

