using System.Text.Json.Serialization;

namespace NewWorldFansBlog.Commands.Models
{
    public class RedditChildrenModel
    {
        [JsonPropertyName("data")]
        public RedditPostModel? Data { get; set; }
    }
}
