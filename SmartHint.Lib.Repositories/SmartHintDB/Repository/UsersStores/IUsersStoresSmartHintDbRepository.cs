using SmartHint.Lib.Models.DbEntities.SmartHintDB;
using SmartHint.Lib.Models.Filters.UsersStores;
using System.Linq.Expressions;

namespace SmartHint.Lib.Repositories.SmartHintDB.Repository.UsersStores
{
    public interface IUsersStoresSmartHintDbRepository
    {
        public Task<int> CountByQueryAsync(Expression<Func<UserStoreSmartHintDbModel, bool>> query);
        public Task<int> CreateAsync(UserStoreSmartHintDbModel model);
        public Task UpdateAsync(UserStoreSmartHintDbModel model);
        public Task RemoveAsync(Expression<Func<UserStoreSmartHintDbModel, bool>> query);
        public Task<UserStoreSmartHintDbModel> GetByIdAsync(int id);
        public Task<List<UserStoreSmartHintDbModel>> GetAllAsync();
        public Task<List<UserStoreSmartHintDbModel>> GetByFilterAsync(UsersStoresFilter filter);
    }
}
