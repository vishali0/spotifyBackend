using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Requests.UserProfile
{
    public class UserLoginRequest
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
