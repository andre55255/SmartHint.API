using SmartHint.Lib.Models.DbEntities.SmartHintDB;

namespace SmartHint.Lib.Repositories.SmartHintDB.Repository.Configurations
{
    public interface IConfigurationsSmartHintDbRepository
    {
        public Task<ConfigurationSmartHintDbModel> GetByIdAsync(int id);
    }
}
