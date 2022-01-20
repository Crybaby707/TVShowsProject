using TVShows.DAL;
using TVShows.Domain;

namespace TVShows.BL;

public class ContentBL : IContentBL
{
    private readonly IContentRepository _contentRepository;

    public ContentBL(IContentRepository contentRepository)
    {
        _contentRepository = contentRepository;
    }

    public Content CreateContent(Content contents)
    {
        return _contentRepository.CreateContent(contents);
    }

    public bool DeleteContent(int contentId)
    {
        return _contentRepository.DeleteContent(contentId);
    }

    public IList<Content> GetAll()
    {
        return _contentRepository.GetAll();
    }
    
    public Content GetContentById(int contentId)
    {
        return _contentRepository.GetContentById(contentId);
    }

    public Content UpdateContent(Content contents)
    {
        return _contentRepository.UpdateContent(contents);
    }
}

