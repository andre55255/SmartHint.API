using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHint.Lib.Models.Filters.UsersStores;
using SmartHint.Lib.Models.Inputs.UsersStores;
using SmartHint.Lib.Models.ViewObjects.Logs;
using SmartHint.Lib.Models.ViewObjects.Utils;
using SmartHint.Lib.Services.Services.UsersStores;
using SmartHint.Lib.Utils.CustomExceptions;
using SmartHint.Lib.Utils.Helpers;
using SmartHint.Lib.Utils.Helpers.LogsApp;
using System.Data;

namespace SmartHint.API.Controllers
{
    [ApiController]
    [Route("user-store")]
    public class UserStoreController : ControllerBase
    {
        private readonly IUsersStoresService _usersStoresService;
        private readonly ILogsAppHelper _logsAppHelper;

        public UserStoreController(IUsersStoresService usersStoresService, ILogsAppHelper logsAppHelper)
        {
            _usersStoresService = usersStoresService;
            _logsAppHelper = logsAppHelper;
        }

        /// <summary>
        /// post - Método para criar novo registro de comprador, passar dados pelo body
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SaveUsersStoresInputVO input)
        {
            try
            {
                await _usersStoresService.CreateAsync(input);

                return StatusCode(StatusCodes.Status201Created, APIResponseVO.Ok($"Comprador registrado com sucesso"));
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
                    Message = $"Falha inesperada ao processar criação de comprador",
                    Place = this.GetPlace(),
                    Exception = ex,
                    Object = input
                });
                return StatusCode(StatusCodes.Status500InternalServerError, APIResponseVO.Fail($"Falha inesperada ao processar criação de registro de comprador"));
            }
        }

        /// <summary>
        /// put - Método para atualizar registro de comprador, passar id como parâmetro na url /{int} e dados para atualização pelo body
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int? id, [FromBody] SaveUsersStoresInputVO input)
        {
            try
            {
                id.IsValidId();

                await _usersStoresService.UpdateAsync(id.Value, input);

                return StatusCode(StatusCodes.Status200OK, APIResponseVO.Ok($"Comprador atualizado com sucesso"));
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
                    Message = $"Falha inesperada ao processar atualização de registro de comprador",
                    Place = this.GetPlace(),
                    Exception = ex,
                    Object = new { id, input }
                });
                return StatusCode(StatusCodes.Status500InternalServerError, APIResponseVO.Fail($"Falha inesperada ao processar atualização de registro de comprador"));
            }
        }

        /// <summary>
        /// delete - Método para excluir registro de comprador, passar id como parâmetro na url /{int}
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int? id)
        {
            try
            {
                id.IsValidId();

                await _usersStoresService.RemoveAsync(id.Value);

                return StatusCode(StatusCodes.Status200OK, APIResponseVO.Ok($"Comprador deletado com sucesso"));
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
                    Message = $"Falha inesperada ao processar remoção de registro de comprador",
                    Place = this.GetPlace(),
                    Exception = ex,
                    Object = new { id }
                });
                return StatusCode(StatusCodes.Status500InternalServerError, APIResponseVO.Fail($"Falha inesperada ao processar remoção de registro de comprador com o id {id}"));
            }
        }

        /// <summary>
        /// get-id - Método para buscar registro de comprador por id, passar id como parâmetro na url /{int}
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int? id)
        {
            try
            {
                id.IsValidId();

                var item = await _usersStoresService.GetByIdAsync(id.Value);

                return StatusCode(StatusCodes.Status200OK, APIResponseVO.Ok($"Comprador listado com sucesso", item));
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
                    Message = $"Falha inesperada ao processar busca de registro de comprador",
                    Place = this.GetPlace(),
                    Exception = ex,
                    Object = new { id }
                });
                return StatusCode(StatusCodes.Status500InternalServerError, APIResponseVO.Fail($"Falha inesperada ao processar busca de registro de comprador com o id {id}"));
            }
        }

        /// <summary>
        /// get-all - Método para buscar lista de compradores, passar dados pela query
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var item = await _usersStoresService.GetAllAsync();

                return StatusCode(StatusCodes.Status200OK, APIResponseVO.Ok($"Compradores listados com sucesso", item));
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
                    Message = $"Falha inesperada ao processar busca de registros de compradores",
                    Place = this.GetPlace(),
                    Exception = ex,
                });
                return StatusCode(StatusCodes.Status500InternalServerError, APIResponseVO.Fail($"Falha inesperada ao processar busca de registros de compradores"));
            }
        }

        /// <summary>
        /// get-by-filter - Método para buscar lista de compradores, passar dados pela query
        /// </summary>
        [HttpGet("filter")]
        public async Task<IActionResult> GetByFilterAsync([FromQuery] UsersStoresFilter filter)
        {
            try
            {
                var item = await _usersStoresService.GetByFilterAsync(filter);

                return StatusCode(StatusCodes.Status200OK, APIResponseVO.Ok($"Compradores filtrados listados com sucesso", item));
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
                    Message = $"Falha inesperada ao processar busca de registros de compradores filtrados",
                    Place = this.GetPlace(),
                    Exception = ex,
                    Object = filter
                });
                return StatusCode(StatusCodes.Status500InternalServerError, APIResponseVO.Fail($"Falha inesperada ao processar busca de registros de compradores filtrados"));
            }
        }
    }
}
