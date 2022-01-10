using System.Text.Json.Serialization;

namespace NewWorldFansBlog.Commands.Models
{
    public class RedditDataModel
    {
        [JsonPropertyName("children")]
        public List<RedditChildrenModel>? Childrens { get; set; }
    }
}
