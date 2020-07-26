using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class PlayList
    {
        // public  int PlayListI { get; set; }
        public int Id { get; set; }
        public string PlayListName { get; set; }
        public User User { get; set; }
        public int UserId { get; internal set; }
    }
}
