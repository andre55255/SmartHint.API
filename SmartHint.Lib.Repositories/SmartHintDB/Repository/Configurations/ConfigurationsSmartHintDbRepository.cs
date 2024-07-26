using Microsoft.EntityFrameworkCore;
using SmartHint.Lib.Models.DbEntities.SmartHintDB;
using SmartHint.Lib.Models.ViewObjects.Logs;
using SmartHint.Lib.Repositories.SmartHintDB.Config.Context;
using SmartHint.Lib.Utils.CustomExceptions;
using SmartHint.Lib.Utils.Helpers;
using SmartHint.Lib.Utils.Helpers.LogsApp;

namespace SmartHint.Lib.Repositories.SmartHintDB.Repository.Configurations
{
    public class ConfigurationsSmartHintDbRepository : IConfigurationsSmartHintDbRepository
    {
        private readonly SmartHintDbContext _db;
        private readonly ILogsAppHelper _logsAppHelper;

        public ConfigurationsSmartHintDbRepository(SmartHintDbContext db, ILogsAppHelper logsAppHelper)
        {
            _db = db;
            _logsAppHelper = logsAppHelper;
        }

        public async Task<ConfigurationSmartHintDbModel> GetByIdAsync(int id)
        {
            try
            {
                return 
                    await _db.Configurations
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logsAppHelper.WriteError(new LogErrorVO
                {
                    Exception = ex,
                    Message = $"Falha na listagem de configuração por id {id} da base de dados",
                    Object = id,
                    Place = this.GetPlace()
                });
                throw new RepositoryException($"Falha na listagem de configuração da base de dados", ex);
            }
        }
    }
}
