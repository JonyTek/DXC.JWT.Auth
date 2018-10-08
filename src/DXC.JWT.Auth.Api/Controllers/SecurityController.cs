using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DXC.JWT.Auth.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : ControllerBase
    {
        [HttpGet]
        [Route("insecure")]
        public IActionResult Insecure()
        {
            return Ok("You're in!");
        }

        [HttpGet]
        [Authorize]
        [Route("secure")]
        public IActionResult Secure()
        {
            return Ok("You're in!");
        }
    }
}
