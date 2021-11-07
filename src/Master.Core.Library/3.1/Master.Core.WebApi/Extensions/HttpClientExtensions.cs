using Master.Core.WebApi.Response;
using System;
using System.Collections.Generic;
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
            try
            {
                if (content == null)
                    throw new CustomHttpRequestException(nameof(content));

                string contentResponse = await content
                    .ReadAsStringAsync();

                if (jsonElement != null)
                {
                    var json = JsonDocument.Parse(contentResponse);
                    return string.IsNullOrEmpty(contentResponse) ? default : JsonSerializer.Deserialize<T>(json.RootElement.GetProperty(jsonElement).ToString(), JsonSerializerSettings.Config);
                }

                return string.IsNullOrEmpty(contentResponse) ? default : JsonSerializer.Deserialize<T>(contentResponse, JsonSerializerSettings.Config);
            }
            catch (Exception e)
            {
                var error = CreateContent(new ResponseError { Title = "", Status = 1, Errors = new List<Error>() { new Error { Property = "prop", Message = e.Message } } } );
                return JsonSerializer.Deserialize<T>(await error.ReadAsStringAsync(), JsonSerializerSettings.Config);
            }
        }

        public static Task<HttpResponseMessage> GetJsonAsync(this HttpClient client, string url)
        {
            if (client == null)
                throw new CustomHttpRequestException(nameof(client));

            return client.GetAsync(string.Concat(client.BaseAddress, url));
        }

        public static Task<HttpResponseMessage> PostJsonAsync(this HttpClient client, string url, object data)
        {
            if (client == null)
                throw new CustomHttpRequestException(nameof(client));

            return client.PostAsync(string.Concat(client.BaseAddress, url), CreateContent(data));
        }

        public static Task<HttpResponseMessage> PutJsonAsync(this HttpClient client, string url, object data)
        {
            if (client == null)
                throw new CustomHttpRequestException(nameof(client));

            return client.PutAsync(string.Concat(client.BaseAddress, url), CreateContent(data));
        }

        public static Task<HttpResponseMessage> PatchJsonAsync(this HttpClient client, string url, object data)
        {
            if (client == null)
                throw new CustomHttpRequestException(nameof(client));

            return client.PatchAsync(string.Concat(client.BaseAddress, url), CreateContent(data));
        }

        public static Task<HttpResponseMessage> DeleteJsonAsync(this HttpClient client, string url)
        {
            if (client == null)
                throw new CustomHttpRequestException(nameof(client));

            return client.DeleteAsync(string.Concat(client.BaseAddress, url));
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
