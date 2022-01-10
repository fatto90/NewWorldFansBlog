using System.Text.Json.Serialization;

namespace NewWorldFansBlog.Commands.Models
{
    public class RedditPostContainerModel
    {
        [JsonPropertyName("data")]
        public RedditDataModel? Data { get; set; }
    }
}
