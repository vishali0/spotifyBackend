using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Requests.Songs
{
    public class AddSongRequest
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }

        public string Image { get; set; }
    }
}
