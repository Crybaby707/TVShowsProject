﻿using Microsoft.EntityFrameworkCore;
using TVShows.Domain;

namespace TVShows.Data;

public class TVShowDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TVShows;Trusted_Connection=True;");
    }

    public DbSet<Content> Contents { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserHasRole> UserHasRoles { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserShowList> UsersShowLists { get; set; }

}
