using NewWorldFansBlog.Commands.Models;

namespace NewWorldFansBlog.Models
{
    public class PostsViewModel
    {
        public List<PostModel>? Posts { get; set; }

        public int CurrentPage { get; set; }
    }
}
