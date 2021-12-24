using Microsoft.EntityFrameworkCore;
using TVShows.Domain;

namespace TVShows.Data
{
    public class TVShowDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=hello;Trusted_Connection=True;");
        }

        public DbSet<Contents> Contents { get; set; }

        public DbSet<Genres> Genres { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserHasRole> UserHasRoles { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<UserShowLists> UsersShowLists { get; set; }

    }
}
