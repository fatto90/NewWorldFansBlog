using System.Text.Json.Serialization;

namespace NewWorldFansBlog.Commands.Models
{
    public class RedditPostModel
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("created_utc")]
        public double? CreatedTimestamp { get; set; }

        public DateTimeOffset? Date { 
            get
            {
                if (CreatedTimestamp == null) return null;
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(CreatedTimestamp.Value).ToUniversalTime();
            }
        }

        [JsonPropertyName("author_fullname")]
        public string Author { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("stickied")]
        public bool Pinned { get; set; }

    }
}
