using TVShows.Domain;

namespace TVShows.DAL
{
    public interface IContentRepository
    {
        IList<Contents> GetAll();

        IList<Contents> CreateContent(Contents contents);
    }
}