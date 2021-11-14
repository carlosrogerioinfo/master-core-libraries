using Master.Core.WebApi.CoreServices;
using Master.Core.WebApi.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI.Test.Model;
using WebAPI.Test.Service.Interface;

namespace WebAPI.Test.Service
{
    public class SpotfyService : CoreService, ISpotfyService
    {
        public readonly HttpClient _httpClient;

        public SpotfyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Artist>> GetArtistAsync(string ids, string authorizationToken)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {authorizationToken}");

            var response = await _httpClient
                .GetJsonAsync($"/artists?ids={ids}");

            if (!ResponseErrorHandling(response))
                return null;

            return await response.Content.ReadJsonAsync<IEnumerable<Artist>>("artists");
        }
    }
}
