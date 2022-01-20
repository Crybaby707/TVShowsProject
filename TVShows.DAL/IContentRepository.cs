using TVShows.Domain;

namespace TVShows.DAL;

public interface IContentRepository
{
    IList<Content> GetAll();

    Content CreateContent(Content contents);

    Content UpdateContent(Content contents);

    bool DeleteContent(int contentId); 
        
    Content GetContentById(int contentId);
}
