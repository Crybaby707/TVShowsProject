using Microsoft.EntityFrameworkCore;
using TVShows.Data;
using TVShows.Domain;

namespace TVShows.DAL
{
    public class UserAuthRepository : BaseRepository, IUserAuthRepository
    {
        public UserAuthRepository(Func<TVShowDbContext> getDbContext) : base(getDbContext)
        {
        }

        public User Get(int id)
            => Query(context => context.Users.FirstOrDefault(p => p.UserID == id));

        public User GetByEmailAndPassword(string email, string password)
            => Query(context =>
                context.Users.Include(u => u.UserRole)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefault(p => p.Email == email && p.Password == password));


        public Task<User> GetUserByEmailAsync(string userEmail)
            => Query(context => context.Users.FirstOrDefaultAsync(p => p.Email == userEmail));
    }
}
