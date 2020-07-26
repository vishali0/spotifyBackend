using Spotify.Models;
using Spotify.Requests.PlayLists;
using Spotify.Requests.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Repository.User
{
    public interface IUserRepository
    {
        public bool AddUser(AddUserRequest request);

        public bool UserLogin(UserLoginRequest request);

        public bool UpdateUser(UpdateUserRequest request);
        
    }
}
