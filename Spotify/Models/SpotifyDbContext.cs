using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class SpotifyDbContext: DbContext
    {
        public SpotifyDbContext(DbContextOptions<SpotifyDbContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<SongList> SongLists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DbSet<UsersPlayList> UsersPlayLists { get; set; }

    }
}
