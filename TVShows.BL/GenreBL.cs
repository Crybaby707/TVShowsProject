using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public IList<Genres> CreateGenre(Genres genres)
    {
        return _genreRepository.CreateGenre(genres);
    }

    public IList<Genres> GetAll()
    {
        return _genreRepository.GetAll();
    }


    public IList<Genres> DeleteGenre(int GenreId)
    {
        return _genreRepository.DeleteGenre(GenreId);
    }
}

