using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MediaContext: DbContext
    {
        public MediaContext(DbContextOptions<MediaContext> options): base(options) { }

        public DbSet<Song> Songs { get; set; }
    }
}
