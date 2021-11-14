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

        public async Task<IEnumerable<Artist>> GetArtistAsync(string ids)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer BQDEdAa3AP5-fVl7PUZ0oHrAyiitKmEkuTzKJ04RJoFK-LOeLKnFIs_04xtEssAYAc4psEDKQkvcrpIIuy1UateH7H6RC0d_vUSFn4e5DFFP_wxCWXiS0YVByG3LtgsYN1Z4mIqdQwO1_OIg4qROow25cdPfynxEz7EEwek");

            var response = await _httpClient
                .GetJsonAsync($"/artists?ids={ids}");

            if (!ResponseErrorHandling(response))
                return null;

            return await response.Content.ReadJsonAsync<IEnumerable<Artist>>("artists");
        }
    }
}
