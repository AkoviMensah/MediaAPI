using API.Data;
using API.Dtos;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private MediaContext _context { get; set; }
        public MediaController(MediaContext context)
        {
            _context = context;
        }


        [HttpGet("songs")]
        public async Task<IActionResult> GetSongs()
        {
            return Ok(await _context.Songs.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<Song> GetSong(int id)
        {
            return await _context.Songs.FindAsync(id);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddSong(AddSong item)
        {
            Song song = new Song(item.Id, item.Name, item.Uri);
            await _context.Songs.AddAsync(song);
            await _context.SaveChangesAsync();
            return Ok(song);
        }
    }
}
