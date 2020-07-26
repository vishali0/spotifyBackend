using Spotify.Models;
using Spotify.Requests.Admin;
using Spotify.Requests.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Repository.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly SpotifyDbContext _db;
        public AdminRepository(SpotifyDbContext db)
        {
            this._db = db;
        }

        public bool AdminDetails(AdminRequest request)
        {        
            var name = _db.Admins.Where(a => a.AdminName == request.AdminName && a.AdminPassword==request.Password).FirstOrDefault();
            if (name != null )
            {       
                return true;
            }
            return false;
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

        public bool DeleteSong(int Id)
        {
            SongList songList = _db.SongLists.Find(Id);
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
    }
}
