using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Requests.PlayLists
{
    public class AddSongToPlayListRequest
    {
        public int Id { get; set; }
        public int PlayListId { get; set; }
        //public int SongId { get; internal set; }
        public int SongId { get; set; }
        public int UserId { get; set; }
        //public string SongName { get; set; }
    }
}
