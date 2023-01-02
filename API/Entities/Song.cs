namespace API.Entities
{
    public class Song: Media
    {
        public Song(int id, string name, string uri) : base(id, name, uri)
        {
            this.ImageUri = ""; 
        }

        public string ImageUri { get; set; }

    }
}
