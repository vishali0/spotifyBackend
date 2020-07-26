using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class UsersPlayList
    {
        internal static SongList playList;


        //internal static SongList playList;

        public int Id { get; set; }
        public SongList Song { get; set; }

        public PlayList PlayList { get; set; }
        public User User { get; set; }

        public int SongId { get; internal set; }
        public int UserId { get; internal set; }
        public int PlayListId { get; internal set; }
        
    }
        
}
