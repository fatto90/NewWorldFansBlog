using System.Text.Json.Serialization;

namespace NewWorldFansBlog.Commands.Models
{
    public class PostModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("posted_at")]
        public DateTimeOffset? Date { get; set; }

        [JsonPropertyName("developer_name")]
        public string? Author { get; set; }

        [JsonPropertyName("source_url")]
        public string? Url { get; set; }
    }
}
