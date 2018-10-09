using DXC.JWT.Auth.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DXC.JWT.Auth.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SecurityController : ControllerBase
    {
        [HttpGet]
        [Route("insecure")]
        public IActionResult Insecure()
        {
            return Ok(new { });
        }

        [HttpGet]
        [Authorize("")]
        [Route("secure")]
        public IActionResult Secure()
        {
            return Ok(new {Id = User.Id(), Email = User.Email(), Fullname = User.Fullname()});
        }
    }
}
