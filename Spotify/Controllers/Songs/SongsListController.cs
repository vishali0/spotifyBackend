using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.Repository.Songs;
using Spotify.Requests.Songs;

namespace Spotify.Controllers.Songs
{
    [Route("api/[controller]")]
    [ApiController]

    [EnableCors("CorsPolicy")]
    public class SongsListController : ControllerBase
    {
        private readonly ISongRepository repository;

        public SongsListController(ISongRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("SongLists")]
        public IActionResult SongsLists()
        {
            return Ok(repository.AllSongs());
        }

        /*[HttpPost("AddSong")]
        public IActionResult AddSong(AddSongRequest data)
        {
            return Ok(repository.AddSong(data));
        }

        [HttpDelete("DeleteSong")]
        public IActionResult DeleteSong(int Id)
        {
            return Ok(repository.DeleteSong(Id));
        }

        [HttpPut("UpdateSong")]
        public IActionResult UpdateSong(UpdateSongRequest data)
        {
            return Ok(repository.UpdateSong(data));
        }*/

        [HttpPost("SearchSongName")]
        public IActionResult SearchSong(SearchSongNameRequest data)
        {
            return Ok(repository.SearchSong(data));
        }

        [HttpPost("SearchArtist")]
        public IActionResult SearchArtist(SearchArtistRequest data)
        {
            return Ok(repository.SearchArtist(data));
        }

        [HttpPost("SearchAlbum")]
        public IActionResult SearchAlbum(SearchAlbumRequest data)
        {
            return Ok(repository.SearchAlbum(data));
        }

    }
}
