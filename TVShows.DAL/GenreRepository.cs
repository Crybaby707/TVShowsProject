using System.Linq;
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

    public IList<Genres> CreateGenre(Genres genres)
    {
        Genres genresCreate = genres;
        _context.Genres.Add(genresCreate);
        _context.SaveChanges();
        return _context.Genres.ToList();
    }

    public IList<Genres> GetAll()
    {

        return _context.Genres.ToList();

    }

    public IList<Genres> DeleteGenre(int GenreId)
    {
        Genres GenreToDelete = _context.Genres.FirstOrDefault(u => u.GenreID == GenreId);
        _context.Genres.Remove(GenreToDelete);
        _context.SaveChanges();
        return _context.Genres.ToList();

    }

}