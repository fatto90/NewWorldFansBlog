using NewWorldFansBlog.Commands.Models;

namespace NewWorldFansBlog.Models
{
    public class HomePostsViewModel
    {
        public List<PostModel>? Posts { get; set; }

        public int CurrentPage { get; set; }
    }
}
