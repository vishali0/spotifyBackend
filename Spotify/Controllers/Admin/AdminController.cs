using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.Repository.Admin;
using Spotify.Requests.Admin;
using Spotify.Requests.Songs;

namespace Spotify.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    
    [EnableCors("CorsPolicy")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository repository;
        public AdminController(IAdminRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("Admin")]
        public IActionResult AdminDetails(AdminRequest data)
        {
            var result=repository.AdminDetails(data);
            {
                if (result)
                {
                    return Ok(new { message = "Successfully LoggedIn" });
                }
                return Unauthorized("Authorization failed");
            }
        }

        
        [HttpGet("SongLists")]
        public IActionResult SongsLists()
        {
            return Ok(repository.AllSongs());
        }

        [HttpPost("AddSong")]
        public IActionResult AddSong(AddSongRequest data)
        {
            var result=(repository.AddSong(data));
            {
                if (result)
                {
                    return Ok(new { message = "Successfully Added" });
                }
                return Unauthorized("Authorization failed");
            }
        }

        [HttpDelete("DeleteSong")]
        public IActionResult DeleteSong(int Id)
        {
            return Ok(repository.DeleteSong(Id));
            //return Ok(false);
        }

        [HttpPut("UpdateSong")]
        public IActionResult UpdateSong(UpdateSongRequest data)
        {
            var result=(repository.UpdateSong(data));
            {
                if (result)
                {
                    return Ok(new { message = "Successfully Edited" });
                }
                return Unauthorized("Authorization failed");
            }
        }

    }
}
