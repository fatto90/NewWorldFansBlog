using NewWorldFansBlog.Commands.Models;

namespace NewWorldFansBlog.Commands.Requests
{
    public class GetRedditPostsRequest
    {
        public int Page { get; set; }
        public DirectionType Direction { get; set; }
        public string PostName { get; set; }
        public PostFilterType SelectedFilter { get; set; }
    }
}
