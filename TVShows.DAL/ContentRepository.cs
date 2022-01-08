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

    public IList<Content> GetAll()
    {
        return _context.Contents.ToList();
    }

    public Content GetContentById(int contentId)
    {
        var content = _context.Contents.FirstOrDefault(f => f.ContentID == contentId);
        return content;

    }

    public Content CreateContent(Content contents)
    {
        Content contentsCreate = contents;
        _context.Contents.Add(contentsCreate);
        _context.SaveChanges();
        return contents;
    }

    public bool DeleteContent(int contentId)
    {
        try
        {
            Content contentToDelete = _context.Contents.FirstOrDefault(u => u.ContentID == contentId);
            if (contentToDelete == null)
            {
                return false;
            }
            _context.Contents.Remove(contentToDelete);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

}