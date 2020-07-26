using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Requests.Songs
{
    public class UpdateSongRequest : AddSongRequest
    {
        public int Id { get; set; }
    }
}
