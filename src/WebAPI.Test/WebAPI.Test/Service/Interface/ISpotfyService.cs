using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Test.Model;

namespace WebAPI.Test.Service.Interface
{
    public interface ISpotfyService
    {
        Task<IEnumerable<Artist>> GetArtistAsync(string ids, string authorizationToken);
        Task<IEnumerable<Album>> GetAlbumAsync(string ids, string authorizationToken, string market);
    }
}
