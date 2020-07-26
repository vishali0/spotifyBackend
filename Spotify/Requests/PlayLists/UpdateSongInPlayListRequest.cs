using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Requests.PlayLists
{
    public class UpdateSongInPlayListRequest : AddSongToPlayListRequest
    {
        public int Id { get; set; }
    }
}
