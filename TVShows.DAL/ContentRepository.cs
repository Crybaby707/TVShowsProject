using System.Linq;
using TVShows.Data;
using TVShows.Domain;

namespace TVShows.DAL;

public class ContentRepository : IContentRepository
{

    private readonly TVShowDbContext _context;

    public ContentRepository(TVShowDbContext context)
    {
        _context = context;

    }

    public IList<Contents> GetAll()
    {
        return _context.Contents.ToList();
    }

    public IList<Contents> CreateContent(Contents contents)
    {
        Contents contentsCreate = contents;
        _context.Contents.Add(contentsCreate);
        _context.SaveChanges();
        return _context.Contents.ToList();
    }
}