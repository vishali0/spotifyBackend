using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Requests.PlayLists
{
    public class DeletePlayListRequest
    {
        public int PlayListId { get; set; }
        public int songId { get; set; }
        public int UserId { get; set; }
    }
}
