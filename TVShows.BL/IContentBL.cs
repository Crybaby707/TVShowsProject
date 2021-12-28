using TVShows.Domain;

namespace TVShows.BL;

public interface IContentBL
{
    IList<Contents> GetAll();
    IList<Contents> CreateContent(Contents contents);
}
