using Microsoft.AspNetCore.Mvc;
using SmartHint.Lib.Models.ViewObjects.Utils;
using SmartHint.Lib.Utils.CustomExceptions;
using SmartHint.Lib.Utils.Helpers;
using SmartHint.Lib.Utils.Helpers.LogsApp;

namespace SmartHint.API.Controllers
{
    [ApiController]
    [Route("test")]
    public class _TestController : ControllerBase
    {
        private readonly ILogsAppHelper _logAppHelper;

        public _TestController(ILogsAppHelper logAppHelper)
        {
            _logAppHelper = logAppHelper;
        }

        [HttpGet]
        public IActionResult GetTest()
        {
            _logAppHelper.WriteError(new Lib.Models.ViewObjects.Logs.LogErrorVO
            {
                Message = "Teste de gravação de log helper",
                Place = this.GetPlace(),
                Exception = new ServiceException($"Exceção teste"),
                Object = new
                {
                    teste = "hello world"
                }
            });
            return StatusCode(StatusCodes.Status200OK, APIResponseVO.Ok("Hello World!"));
        }
    }
}
