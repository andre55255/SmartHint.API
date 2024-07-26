using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHint.Lib.Models.ViewObjects.Logs;
using SmartHint.Lib.Models.ViewObjects.Utils;
using SmartHint.Lib.Services.Services.Configurations;
using SmartHint.Lib.Utils.CustomExceptions;
using SmartHint.Lib.Utils.Helpers;
using SmartHint.Lib.Utils.Helpers.LogsApp;

namespace SmartHint.API.Controllers
{
    [ApiController]
    [Route("configuration")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationsService _configurationsService;
        private readonly ILogsAppHelper _logsAppHelper;

        public ConfigurationController(IConfigurationsService configurationsService, ILogsAppHelper logsAppHelper)
        {
            _configurationsService = configurationsService;
            _logsAppHelper = logsAppHelper;
        }

        /// <summary>
        /// is-state-registration-for-pf - Método para verificar se a configuração de inscrição estadual para PF está ativa, sem parâmetros
        /// </summary>
        [HttpGet("is-state-registration-for-pf")]
        public async Task<IActionResult> IsStateRegistrationForPFAsync()
        {
            try
            {
                var result = await _configurationsService.IsStateRegistrationForPFAsync();

                return StatusCode(StatusCodes.Status200OK, APIResponseVO.Ok($"Configuração validada com sucesso", result));
            }
            catch (ConflicException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, APIResponseVO.Fail(ex.Message));
            }
            catch (ForbbidenException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, APIResponseVO.Fail(ex.Message));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, APIResponseVO.Fail(ex.Message));
            }
            catch (ServiceException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logsAppHelper.WriteError(new LogErrorVO
                {
                    Message = $"Falha inesperada ao processar verificação de configuração IE PF",
                    Place = this.GetPlace(),
                    Exception = ex,
                });
                return StatusCode(StatusCodes.Status500InternalServerError, APIResponseVO.Fail($"Falha inesperada ao processar verificação de configuração IE PF"));
            }
        }
    }
}
