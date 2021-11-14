using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Core.WebApi.Controller
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected BaseController() { }

        protected new async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
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
                var message = notifications.FirstOrDefault();
                return BadRequest(new
                {
                    success = false,
                    error = new { code = message.Property, message = message.Message }
                });
            }
        }
    }
}
