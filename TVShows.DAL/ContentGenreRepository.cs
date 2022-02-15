using TVShows.Data;
using TVShows.Domain;


namespace TVShows.DAL;


    public class ContentGenreRepository : IContentGenreRepository
    {

        private readonly TVShowDbContext _context;

        public ContentGenreRepository(TVShowDbContext context)
        {
            _context = context;

        }

        public ContentGenre CreateContentGenre(ContentGenre contentGenres)
        {
            ContentGenre contentGenresCreate = contentGenres;
            _context.ContentGenres.Add(contentGenresCreate);
            _context.SaveChanges();
            return contentGenres;
        }
 

        public bool DeleteContentGenre(int contentGenreID)
        {
            try
            {
                ContentGenre contentGenresToDelete = _context.ContentGenres.FirstOrDefault(u => u.ContentGenreID == contentGenreID);
                if (contentGenresToDelete == null)
                {
                    return false;
                }
                _context.ContentGenres.Remove(contentGenresToDelete);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IList<ContentGenre> GetAll()
        {
        return _context.ContentGenres.ToList();
    }

        public ContentGenre GetContentGenreById(int contentGenreID)
        {
        var contentGenre = _context.ContentGenres.FirstOrDefault(f => f.ContentGenreID == contentGenreID);
        return contentGenre;
        }

        public ContentGenre UpdateContentGenre(ContentGenre contentGenres)
        {
            try
            {
                if (contentGenres == null)
                {
                    return null;
                }
                _context.ContentGenres.Update(contentGenres);
                _context.SaveChanges();
                return contentGenres;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
