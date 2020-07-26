using Spotify.Models;
using Spotify.Requests.Admin;
using Spotify.Requests.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Repository.Admin
{
    public interface IAdminRepository

    {
        public bool AdminDetails(AdminRequest request);

        public List<SongList> AllSongs();

        public bool AddSong(AddSongRequest request);

        public bool DeleteSong(int Id);

        public bool UpdateSong(UpdateSongRequest request);
    }
}
