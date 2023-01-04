using API.Dtos;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class MediaRepository : IRepository
    {
        private MediaContext _context { get; set; }
        public MediaRepository(MediaContext context)
        {
            _context = context;
        }

        
        public async Task<bool> Add(AddSong item)
        {
            var data = await _context.Songs.FindAsync(item.Id);
            if (data == null)
            {
                Song song = new Song(item.Id, item.Name, item.Uri);
                _context.Songs.AddAsync(song);
                _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _context.Songs.FindAsync(id);

            if (data == null) return false;
            else
            {
                _context.Songs.Remove(data);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Song> Get(int id)
        {
            return await _context.Songs.FindAsync(id);
        }

        public async Task<List<Song>> GetAll()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<Song> Update(UpdateSong item)
        {
            var data = await _context.Songs.FindAsync(item.Id);
            if (data != null)
            {
                data.Name = item.Name;
                data.Uri = item.Uri;

                _context.Songs.Update(data);
                await _context.SaveChangesAsync();
            }
            return data;
        }
    }
}
