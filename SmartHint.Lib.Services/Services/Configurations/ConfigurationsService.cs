using SmartHint.Lib.Models.Enums;
using SmartHint.Lib.Models.ViewObjects.Logs;
using SmartHint.Lib.Repositories.SmartHintDB.Repository.Configurations;
using SmartHint.Lib.Utils.CustomExceptions;
using SmartHint.Lib.Utils.Helpers;
using SmartHint.Lib.Utils.Helpers.LogsApp;

namespace SmartHint.Lib.Services.Services.Configurations
{
    public class ConfigurationsService : IConfigurationsService
    {
        private readonly IConfigurationsSmartHintDbRepository _configurationsSmartHintDbRepo;
        private readonly ILogsAppHelper _logsAppHelper;

        public ConfigurationsService(IConfigurationsSmartHintDbRepository configurationsSmartHintDbRepo, ILogsAppHelper logsAppHelper)
        {
            _configurationsSmartHintDbRepo = configurationsSmartHintDbRepo;
            _logsAppHelper = logsAppHelper;
        }

        public async Task<bool> IsStateRegistrationForPFAsync()
        {
            try
            {
                var data = await _configurationsSmartHintDbRepo.GetByIdAsync(ConfigurationsEnum.IS_STATE_REGISTRATION_FOR_PF.GetHashCode());

                if (data == null)
                    return false;

                return data.Value == "1";
            }
            catch (ConflicException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (ServiceException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logsAppHelper.WriteError(new LogErrorVO
                {
                    Exception = ex,
                    Message = $"Falha inesperada ao verificar configuração IE",
                    Place = this.GetPlace()
                });
                throw new ServiceException($"Falha inesperada ao verificar configuração IE", ex);
            }
        }
    }
}
