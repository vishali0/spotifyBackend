using Spotify.Models;
//using Spotify.Models.SongList;
using Spotify.Requests.Songs;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Repository.Songs
{
    public class SongRepository : ISongRepository
    {
        private readonly SpotifyDbContext _db;

        

        public SongRepository(SpotifyDbContext db)
        {
            this._db = db;
        }

        public List<SongList> AllSongs()
        {
            return _db.SongLists.ToList();
        }

        public bool AddSong(AddSongRequest request)
        {
            if (request != null)
            {
                SongList songList = new SongList();
                //songList.Id = request.Id;
                songList.SongName = request.Name;
                songList.Url = request.Url;
                songList.Artist = request.Artist;
                songList.Album = request.Album;
                songList.image = request.Image;


                _db.SongLists.Add(songList);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteSong(int id)
        {            
            SongList songList = _db.SongLists.Find(id);
            //songList.Id = request.Id;
            if (songList == null)
            {
                return false;
            }             

                _db.SongLists.Remove(songList);
                _db.SaveChanges();
                return true;
            
        }

        public bool UpdateSong(UpdateSongRequest request)
        {
            if (request != null)
            {
                var song = _db.SongLists.Where(a => a.Id == request.Id).FirstOrDefault();
                if (song != null)
                {
                    song.SongName = string.IsNullOrEmpty(request.Name) ? song.SongName : request.Name;
                    song.Url = string.IsNullOrEmpty(request.Url) ? song.Url : request.Url;
                    song.Artist = string.IsNullOrEmpty(request.Artist) ? song.Artist : request.Artist;
                    song.Album = string.IsNullOrEmpty(request.Album) ? song.Album : request.Album;
                    song.image = string.IsNullOrEmpty(request.Image) ? song.image : request.Image;

                    _db.SaveChanges();

                    return true;

                }
                return false;
            }
            return false;
        }

        public List<SongList> SearchSong(SearchSongNameRequest request)
        {
               var SongName = request.SongName;
                if (SongName != null)
                {
                var song = _db.SongLists.Where(a => a.SongName.Contains(request.SongName)).ToList();
                return song;
               
                }
            return null;
                                   
        }

        public List<SongList> SearchAlbum(SearchAlbumRequest request)
        {
            var AlbumName = request.Album;
            if (AlbumName != null)
            {
                var song = _db.SongLists.Where(a => a.Album.Contains(request.Album)).ToList();
                return song;

            }
            return null;

        }

        public List<SongList> SearchArtist(SearchArtistRequest request)
        {
            var ArtistName = request.artist;
            if (ArtistName != null)
            {
                var song = _db.SongLists.Where(a => a.SongName.Contains(request.artist)).ToList();
                return song;

            }
            return null;

        }
    }
}
