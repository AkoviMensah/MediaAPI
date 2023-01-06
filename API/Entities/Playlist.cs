namespace API.Entities
{
    public class Playlist
    {
        public int Id { get; set; }
        public string User { get; set; }
        public List<Song> Songs { get; set; }
        public bool Shared { get; set; }
    }
}
