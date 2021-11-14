using Master.Core.WebApi.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Test.Model;
using WebAPI.Test.Service;

namespace WebAPI.Test.Controllers
{
    [Route("spotfy/v1")]
    public class SpotfyController : BaseController
    {
        private readonly SpotfyService _service;

        public SpotfyController(SpotfyService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("artists")]
        [ProducesResponseType(typeof(IEnumerable<Artist>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllArtists(string ids)
        {
            return await Response(await _service.GetArtistAsync(ids), _service.Notifications);
        }

    }
}
