using Master.Core.WebApi.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Master.Core.WebApi.Controller
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected BaseController() { }

        protected new async Task<IActionResult> Response(object result, ResponseResult notifications = null)
        {
            if (notifications == default)
            {
                try
                {
                    await Task.CompletedTask;
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma falha interna no servidor." }
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notifications.Errors
                });
            }
        }
    }
}
