using Microsoft.EntityFrameworkCore;
using TVShows.Data;
using TVShows.Domain;

namespace TVShows.DAL
{
    public class UserAuthRepository : IUserAuthRepository
    {
        public readonly TVShowDbContext _context;

        public UserAuthRepository(TVShowDbContext context)
        {
            _context = context;
        }

        public User Get(int id)
        {
            var user = _context.Users.FirstOrDefault(p => p.UserID == id);
            return user;
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return _context.Users.Include(u => u.UserRole)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefault(p => p.Email == email && p.Password == password);
        }

        public Task<User> GetUserByEmailAsync(string userEmail)
        {
            throw new NotImplementedException();
        }


        //public Task<User> GetUserByEmailAsync(string userEmail)
        //    => Query(context => context.Users.FirstOrDefaultAsync(p => p.Email == userEmail));
    }
}
