namespace NewWorldFansBlog.Models
{
    public class PostViewModel
    {
        public string Url { get; set; }

        public string Subtitle { get; set; }

        public string Author { get; set; }

        public DateTimeOffset? Date { get; set; }

        public bool Pinned { get; set; }

        public string Name { get; set; }
    }
}
