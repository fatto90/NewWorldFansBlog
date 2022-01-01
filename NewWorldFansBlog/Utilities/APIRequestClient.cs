using System.Net.Http.Headers;
using System.Text.Json;

namespace NewWorldFansBlog.Utilities
{
    public class APIRequestClient<T> : IAPIRequestClient<T>
    {
        private static HttpClient? Client { get; set; }

        public APIRequestClient()
        {
            Client = new HttpClient();
        }

        public async Task<T?> GetResponse(string url)
        {
            Client!.DefaultRequestHeaders.Accept.Clear();
            Client!.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var streamTask = Client!.GetStreamAsync(url);
                var response = await streamTask;
                var result = await JsonSerializer.DeserializeAsync<T>(response);

                return result;
            } catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
