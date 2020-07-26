using Spotify.Models;
using Spotify.Requests.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Repository.Songs
{
    public interface ISongRepository
    {
        public List<SongList> AllSongs();

        public List<SongList> SearchSong(SearchSongNameRequest request);

        public List<SongList> SearchArtist(SearchArtistRequest request);

        public List<SongList> SearchAlbum(SearchAlbumRequest request);

        public bool AddSong(AddSongRequest request);

        public bool DeleteSong(int Id);

        public bool UpdateSong(UpdateSongRequest request);
    }
}
