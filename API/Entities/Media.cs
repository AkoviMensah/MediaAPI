namespace API.Entities
{
    public abstract class Media
    {
        protected Media(int id, string name, string uri)
        {
            Id = id;
            Name = name;
            Uri = uri;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
    }
}
