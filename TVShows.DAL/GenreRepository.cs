using TVShows.Data;
using TVShows.Domain;

namespace TVShows.DAL;

public class GenreRepository : IGenreRepository
{

    private readonly TVShowDbContext _context;

    public GenreRepository(TVShowDbContext context)
    {
        _context = context;

    }

    public Genre CreateGenre(Genre genres)
    {
        Genre genresCreate = genres;
        _context.Genres.Add(genresCreate);
        _context.SaveChanges();
        return genresCreate;
    }

    public IList<Genre> GetAll()
    {

        return _context.Genres.ToList();

    }

    public Genre GetGenreById(int genreId)
    {
        var genre = _context.Genres.FirstOrDefault(f => f.GenreID == genreId);
        return genre;

    }

    public bool DeleteGenre(int genreId)
    {
        try
        {
            Genre genreToDelete = _context.Genres.FirstOrDefault(u => u.GenreID == genreId);
            if (genreToDelete == null)
            {
                return false;
            }
            _context.Genres.Remove(genreToDelete);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public Genre UpdateGenre(Genre genres)
    {
        try
        {
            if (genres == null)
            {
                return null;
            }
            _context.Genres.Update(genres);
            _context.SaveChanges();
            return genres;
        }
        catch (Exception)
        {
            return null;
        }
    }
}