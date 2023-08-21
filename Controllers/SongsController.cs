using Microsoft.AspNetCore.Mvc;
using Music_LibraryBackend.Data;
using Music_LibraryBackend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Music_LibraryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<SongsController>
        [HttpGet]
        public IActionResult Get()
        {
            var songs = _context.Songs.ToList();
            return Ok(songs);
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var song = _context.Songs.Find(id);
            if (song == null)
                return NotFound();
            return Ok(song);
        }

        // POST api/<SongsController>
        [HttpPost]
        public IActionResult Post([FromBody] Song song)
        {
            _context.Songs.Add(song);
            _context.SaveChanges();
            return StatusCode(201, song);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Song song)
        {
            var songToUpdate = _context.Songs.Find(id);
            if (songToUpdate == null)
                return NotFound();
            songToUpdate.Title = song.Title;
            songToUpdate.Artist = song.Artist;
            songToUpdate.Album = song.Album;
            songToUpdate.Genre = song.Genre;
            songToUpdate.ReleaseDate = song.ReleaseDate;
            songToUpdate.Likes = song.Likes;
            _context.SaveChanges();
            return Ok(song);


        }
        [HttpPatch("{id}/Like")]
        public IActionResult Like(int id)
        {
            var songToUpdate = _context.Songs.FirstOrDefault(m => m.Id == id);
            if (songToUpdate == null)
                return NotFound();
            songToUpdate.Likes += 1;
            _context.SaveChanges();
            return Ok(songToUpdate);

        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var songToRemove = _context.Songs.FirstOrDefault(m => m.Id == id);
            if (songToRemove == null)
                return NotFound();
            _context.Songs.Remove(songToRemove);
            _context.SaveChanges();
            return NoContent();

        }
        
    }
}
