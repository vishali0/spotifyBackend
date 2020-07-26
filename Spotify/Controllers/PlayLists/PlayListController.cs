using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.Repository.PlayListDetails;
using Spotify.Requests.PlayLists;

namespace Spotify.Controllers.PlayLists
{
    [Route("api/[controller]")]
    [ApiController]

    [EnableCors("CorsPolicy")]
    public class PlayListController : ControllerBase

    {
        private readonly IPlayListRepository repository;

        public PlayListController(IPlayListRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("UsersPlayLists")]
        public IActionResult UsersPlayLists()
        {
            return Ok(repository.AllPlayLists());
        }

        [HttpPost("CreatePlayList")]
        public IActionResult AddPlayList(AddPlayListRequest data)
        {
            var result=(repository.AddPlayList(data));
            {
                if (result)
                {
                    return Ok(new { message = "Successfully Added" });
                }
                return Unauthorized("Authorization failed");
            }
        }        

        [HttpPut("EditPlayList")]
        public IActionResult UpdatePlayList(UpdatePlayListRequest data)
        {
            return Ok(repository.UpdatePlayList(data));
        }

        [HttpDelete("DeletePlayList")]
        public IActionResult DeletePlayList(int Id)
        {
            return Ok(repository.DeletePlayList(Id));
        }

        [HttpPost("AddSongsToPlayList")]
        public IActionResult AddSongsToPlayList(AddSongToPlayListRequest data)
        {
            return Ok(repository.AddSongsToPlayList(data));
        }

        /*[HttpPut("UpdateSongsInPlayList")]
        public IActionResult UpdateSongsInPlayList(UpdateSongInPlayListRequest data)
        {
            return Ok(repository.UpdateSongsInPlayList(data));
        }*/

        [HttpDelete("DeleteSongsFromPlayList")]
        public IActionResult DeleteSongsFromPlayList(DeletePlayListRequest data)
        {
            return Ok(repository.DeleteSongsFromPlayList(data));
        }

        [HttpGet("GetSongsByPlayListId")]
        public IActionResult GetSongsByPlayList(int Id)
        {
            return Ok(repository.GetSongsByPlayList(Id));
        }
    }
}
