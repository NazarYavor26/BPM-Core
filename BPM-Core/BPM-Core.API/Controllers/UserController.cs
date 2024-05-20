using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BPM_Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {}

        [HttpGet("username")]
        public ActionResult GetUserName()
        {
            return Ok("Usernamae is Floyer");
        }
    }
}
