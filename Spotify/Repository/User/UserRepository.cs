using Spotify.Models;
using Spotify.Requests.PlayLists;
using Spotify.Requests.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly SpotifyDbContext _db;
        public UserRepository(SpotifyDbContext db)
        {
            this._db = db;
        }

        public bool AddUser(AddUserRequest request)
        {
            if (request != null)
            {
                Models.User user = new Models.User();
                user.UserName = request.UserName;
                user.UserPassword = request.UserPassword;
                user.MobileNumber = request.MobileNumber;
                user.Email = request.Email;


                _db.Users.Add(user);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UserLogin(UserLoginRequest request)
        {
            
            var name = _db.Users.Where(a => a.UserName == request.UserName && a.UserPassword == request.UserPassword).FirstOrDefault();
            if (name != null)
            {
                return true;
            }
            return false;
        }

        public bool UpdateUser(UpdateUserRequest request)
        {
            if (request != null)
            {
                var userList = _db.Users.Where(a => a.Id == request.Id).FirstOrDefault();

                if(userList != null) {
                    userList.UserName = string.IsNullOrEmpty(request.UserName) ? userList.UserName : request.UserName;
                    userList.UserPassword = string.IsNullOrEmpty(request.UserPassword) ? userList.UserPassword : request.UserPassword;
                    //userList.MobileNumber = long.HasValue(request.MobileNumber) ? userList.MobileNumber : request.MobileNumber;
                    userList.Email = string.IsNullOrEmpty(request.Email) ? userList.Email : request.Email;
                    if (request.MobileNumber != 0)
                    {
                      userList.MobileNumber = request.MobileNumber;
                    }
                        _db.SaveChanges();

                    return true;

                }
                return false;
                
            }
            return false;
        }

        
    }
}
