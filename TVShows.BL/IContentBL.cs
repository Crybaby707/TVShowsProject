using TVShows.Domain;

namespace TVShows.BL;

public interface IContentBL
{
    IList<Content> GetAll();

    Content CreateContent(Content contents);

    Content UpdateContent(Content contents);

    bool DeleteContent(int contentId);

    Content GetContentById(int contentId);
}
