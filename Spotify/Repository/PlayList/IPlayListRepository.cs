using Spotify.DTO;
using Spotify.Models;
using Spotify.Requests.PlayLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Repository.PlayListDetails
{
    public interface IPlayListRepository
    {
        public List<PlayListDTO> AllPlayLists();

        public bool AddPlayList(AddPlayListRequest request);

        public bool DeletePlayList(int Id);        

        public bool UpdatePlayList(UpdatePlayListRequest request);

        public bool AddSongsToPlayList(AddSongToPlayListRequest request);

        //public bool UpdateSongsInPlayList(UpdateSongInPlayListRequest request);

        public List<SongList> GetSongsByPlayList(int PlayListId);

        public bool DeleteSongsFromPlayList(DeletePlayListRequest request);
    }
}
