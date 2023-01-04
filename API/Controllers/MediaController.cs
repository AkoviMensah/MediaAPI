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
        private IRepository _repo { get; set; }
        public MediaController(IRepository repo)
        {
            _repo = repo;
        }


        [HttpGet("songs")]
        public async Task<IActionResult> GetSongs()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<Song> GetSong(int id)
        {
            return await _repo.Get(id);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddSong(AddSong item)
        {
            var added = await _repo.Add(item);
            if (added) return Ok(item);
            return BadRequest("Alreaday in DB");
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateSong(UpdateSong item)
        {
            var updated = await _repo.Update(item);
            if (updated != null) return Ok(updated);
            return BadRequest("Not found in DB");
        }
    }
}
