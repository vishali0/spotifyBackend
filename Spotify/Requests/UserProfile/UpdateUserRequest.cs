using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Requests.UserProfile
{
    public class UpdateUserRequest : AddUserRequest
    {
        public int Id { get; set; }
    }
}
