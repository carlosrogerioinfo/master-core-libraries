using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Master.Core.WebApi.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadJsonAsync<T>(this HttpContent content, string jsonElement = null)
        {
            if (content == null)
            {
                throw new CustomHttpRequestException(nameof(content));
            }

            string contentResponse = await content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            if (jsonElement != null)
            {
                var json = JsonDocument.Parse(contentResponse);
                return string.IsNullOrEmpty(contentResponse) ? default : JsonSerializer.Deserialize<T>(json.RootElement.GetProperty(jsonElement).ToString(), JsonSerializerSettings.Config);
            }

            return string.IsNullOrEmpty(contentResponse) ? default : JsonSerializer.Deserialize<T>(contentResponse, JsonSerializerSettings.Config);
        }

        public static Task<HttpResponseMessage> GetJsonAsync(this HttpClient client, string url)
        {
            if (client == null)
            {
                throw new CustomHttpRequestException(nameof(client));
            }

            return client.GetAsync(url);
        }

        public static Task<HttpResponseMessage> PostJsonAsync(this HttpClient client, string url, object data)
        {
            if (client == null)
            {
                throw new CustomHttpRequestException(nameof(client));
            }

            return client.PostAsync(url, CreateContent(data));
        }

        public static Task<HttpResponseMessage> PutJsonAsync(this HttpClient client, string url, object data)
        {
            if (client == null)
            {
                throw new CustomHttpRequestException(nameof(client));
            }

            return client.PutAsync(url, CreateContent(data));
        }

        public static Task<HttpResponseMessage> PatchJsonAsync(this HttpClient client, string url, object data)
        {
            if (client == null)
            {
                throw new CustomHttpRequestException(nameof(client));
            }

            return client.PatchAsync(url, CreateContent(data));
        }

        public static Task<HttpResponseMessage> DeleteJsonAsync(this HttpClient client, string url)
        {
            if (client == null)
            {
                throw new CustomHttpRequestException(nameof(client));
            }

            return client.DeleteAsync(url);
        }

        private static HttpContent CreateContent(object content)
        {
            var stringContent = JsonSerializer.Serialize(content, JsonSerializerSettings.Config);
            return new StringContent(stringContent, Encoding.UTF8, MediaTypeNames.Application.Json);
        }

        private class JsonSerializerSettings
        {
            public static readonly JsonSerializerOptions Config = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }
    }
}
