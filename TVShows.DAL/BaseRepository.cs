
using TVShows.Data;

namespace TVShows.DAL
{
    public class BaseRepository
    {

        private readonly Lazy<TVShowDbContext> lazyContext;

        private TVShowDbContext context => lazyContext.Value;


        protected readonly Func<TVShowDbContext> getDbContext;

        public BaseRepository(Func<TVShowDbContext> getDbContext)
        {
            this.getDbContext = getDbContext;
            lazyContext = new Lazy<TVShowDbContext>(() => getDbContext());
        }

        protected T Execute<T>(Func<TVShowDbContext, T> functor)
        {
            using (var dbContext = getDbContext())
            {
                return functor(dbContext);
            }
        }

        protected T Query<T>(Func<TVShowDbContext, T> functor)
        {
            return functor(context);
        }
    }
}
