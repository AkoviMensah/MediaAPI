using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MediaContext: DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public MediaContext(DbContextOptions<MediaContext> options): base(options) { }
    }
}
