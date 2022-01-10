using NewWorldFansBlog.Commands.Models;

namespace NewWorldFansBlog.Models
{
    public class RedditPostsViewModel
    {
        public List<RedditPostModel>? Posts { get; set; }

        public int CurrentPage { get; set; }
    }
}
