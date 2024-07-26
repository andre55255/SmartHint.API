using SmartHint.Lib.Models.Filters.UsersStores;
using SmartHint.Lib.Models.Inputs.UsersStores;
using SmartHint.Lib.Models.ViewObjects.UsersStores;

namespace SmartHint.Lib.Services.Services.UsersStores
{
    public interface IUsersStoresService
    {
        public Task CreateAsync(SaveUsersStoresInputVO model);
        public Task UpdateAsync(int id, SaveUsersStoresInputVO model);
        public Task RemoveAsync(int id);
        public Task<UsersStoresGetVO> GetByIdAsync(int id);
        public Task<List<UsersStoresGetVO>> GetAllAsync();
        public Task<List<UsersStoresGetVO>> GetByFilterAsync(UsersStoresFilter filter);
    }
}
