using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class SongList
    {
        public int Id { get; set; }
        public string SongName { get; set; }
        public string Url { get; set; }
        public string Artist { get; set; }

        public string Album { get; set; }
        public string image { get; set; }
        //public int PlayListId { get; internal set; }
        //public object PlayList { get; internal set; }
        //public string PlayListName { get; internal set; }
        //public int PlayList { get; internal set; }
    }
}
