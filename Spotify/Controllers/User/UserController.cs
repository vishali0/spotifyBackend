using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.Repository.User;
using Spotify.Requests.PlayLists;
using Spotify.Requests.UserProfile;

namespace Spotify.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]

    [EnableCors("CorsPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("RegisterUser")]
        public IActionResult AddUser(AddUserRequest data)
        {
            var result=(repository.AddUser(data));
            if (result)
            {
                return Ok("Login Successful");
            }
            return Unauthorized("Unauthorized Login");
        }

        [HttpPost("UserLogin")]
        public IActionResult UserLogin(UserLoginRequest data)
        {
            var result=repository.UserLogin(data);
            if (result)
            {
                return Ok("Login Successful");
            }
            return Unauthorized("Unauthorized Login");
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(UpdateUserRequest data)
        {
            return Ok(repository.UpdateUser(data));
        }

        /*[HttpGet("UsersPlayLists")]
        public IActionResult UsersPlayLists()
        {
            return Ok(repository.AllPlayLists());
        }

        [HttpPost("AddPlayList")]
        public IActionResult AddPlayList(AddPlayListRequest data)
        {
            return Ok(repository.AddPlayList(data));
        }

        [HttpDelete("DeletePlayList")]
        public IActionResult DeletePlayList(DeletePlayListRequest data)
        {
            return Ok(repository.DeletePlayList(data));
        }

        [HttpPut("UpdatePlayList")]
        public IActionResult UpdatePlayList(UpdatePlayListRequest data)
        {
            return Ok(repository.UpdatePlayList(data));
        }*/

    }
}
