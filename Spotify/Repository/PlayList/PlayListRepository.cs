using Microsoft.EntityFrameworkCore;
using Spotify.DTO;
using Spotify.Models;

using Spotify.Requests.PlayLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Repository.PlayListDetails
{
    public class PlayListRepository : IPlayListRepository
    {
        private readonly SpotifyDbContext _db;

        public int Id { get; private set; }
        public object PlayListId { get; private set; }

        public PlayListRepository(SpotifyDbContext db)
        {
            this._db = db;
        }

        public List<PlayListDTO> AllPlayLists()
        {
            //return _db.PlayLists.ToList();
            List<PlayListDTO> x = new List<PlayListDTO>();
            var play = _db.PlayLists.ToList();
            foreach(PlayList q in play)
            {
                PlayListDTO temp = new PlayListDTO();
                temp.PlayListId = q.Id;
                temp.PlayListName = q.PlayListName;
                x.Add(temp);
            }
            //x.PlayListId=play.Id
            return x;
        }

        public bool AddPlayList(AddPlayListRequest request)
        {
            if (request != null)
            {
                PlayList playList = new PlayList();
                playList.UserId = request.UserId;
                playList.PlayListName = request.PlayListName;                


                _db.PlayLists.Add(playList);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool UpdatePlayList(UpdatePlayListRequest request)
        {
            if (request != null)
            {
                var playList = _db.PlayLists.Where(a => a.Id == request.Id).FirstOrDefault();
                if (playList != null)
                {
                    //playList.Song.SongName = string.IsNullOrEmpty(request.SongName) ? playList.Song.SongName : request.SongName;
                    playList.PlayListName = string.IsNullOrEmpty(request.PlayListName) ? playList.PlayListName : request.PlayListName;
                    

                    _db.SaveChanges();

                    return true;

                }
                return false;
            }
            return false;
        }

        public bool DeletePlayList(int id)
        {
            PlayList playList = _db.PlayLists.Find(id);
            if (playList == null)
            {
                return false;
            }
            _db.PlayLists.Remove(playList);
            _db.SaveChanges();
            return true;

        }

        public bool AddSongsToPlayList(AddSongToPlayListRequest request)
        {
            if (request != null)
            {
                UsersPlayList playList = new UsersPlayList();
                playList.SongId = request.SongId;
                playList.PlayListId = request.PlayListId;
                playList.UserId = request.UserId;

                _db.UsersPlayLists.Add(playList);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

       /* public bool UpdateSongsInPlayList(UpdateSongInPlayListRequest request)
        {
            if (request != null)
            {
                var playList = _db.UsersPlayLists.Where(a => a.Id == request.Id).FirstOrDefault();
                if (playList != null)
                {
                    playList.SongName = string.IsNullOrEmpty(request.SongName) ? playList.SongName : request.SongName;
                    
                    _db.SaveChanges();

                    return true;

                }
                return false;
            }
            return false;
        }*/


        public bool DeleteSongsFromPlayList(DeletePlayListRequest request)
        {
            if (request != null)
            {
                UsersPlayList songList = new UsersPlayList();
                songList = _db.UsersPlayLists.Where(a => a.SongId == request.songId && a.PlayListId == request.PlayListId && a.UserId==request.UserId).FirstOrDefault();
                _db.UsersPlayLists.Remove(songList);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<SongList> GetSongsByPlayList(int PlayListId)
        {
            List<SongList> SongsByPlayList = new List<SongList>();


            List<UsersPlayList> songs = _db.UsersPlayLists.Include(a=>a.Song).Where(a => a.PlayListId == PlayListId).ToList();
            foreach(UsersPlayList song in songs)
            {
                SongsByPlayList.Add(song.Song);

            }
            
            return SongsByPlayList;
        }

    }
}
