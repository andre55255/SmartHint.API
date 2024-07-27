using Microsoft.AspNetCore.Mvc;
using SmartHint.Lib.Models.ViewObjects.Utils;

namespace SmartHint.API.Controllers
{
    [ApiController]
    [Route("test")]
    public class _TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTest()
        {
            return StatusCode(StatusCodes.Status200OK, APIResponseVO.Ok("Hello World!"));
        }
    }
}
