using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHint.Lib.Models.DbEntities.SmartHintDB;
using SmartHint.Lib.Models.Filters.UsersStores;
using SmartHint.Lib.Models.ViewObjects.Logs;
using SmartHint.Lib.Repositories.SmartHintDB.Config.Context;
using SmartHint.Lib.Utils.CustomExceptions;
using SmartHint.Lib.Utils.Helpers;
using SmartHint.Lib.Utils.Helpers.LogsApp;
using System.Linq.Expressions;

namespace SmartHint.Lib.Repositories.SmartHintDB.Repository.UsersStores
{
    public class UsersStoresSmartHintDbRepository : IUsersStoresSmartHintDbRepository
    {
        private readonly SmartHintDbContext _db;
        private readonly ILogsAppHelper _logsAppHelper;
        private readonly IMapper _mapper;

        public UsersStoresSmartHintDbRepository(SmartHintDbContext db, ILogsAppHelper logsAppHelper, IMapper mapper)
        {
            _db = db;
            _logsAppHelper = logsAppHelper;
            _mapper = mapper;
        }

        public async Task<int> CountByQueryAsync(Expression<Func<UserStoreSmartHintDbModel, bool>> query)
        {
            try
            {
                return
                    await _db.UsersStores
                             .AsNoTracking()
                             .CountAsync(query);
            }
            catch (Exception ex)
            {
                _logsAppHelper.WriteError(new LogErrorVO
                {
                    Exception = ex,
                    Message = $"Falha na verificação de usuário lojista na base de dados",
                    Object = query.Body,
                    Place = this.GetPlace()
                });
                throw new RepositoryException($"Falha na verificação de usuário lojista na base de dados", ex);
            }
        }

        public async Task<int> CreateAsync(UserStoreSmartHintDbModel model)
        {
            try
            {
                _db.UsersStores.Add(model);

                await _db.SaveChangesAsync();

                return model.Id;
            }
            catch (Exception ex)
            {
                _logsAppHelper.WriteError(new LogErrorVO
                {
                    Exception = ex,
                    Message = $"Falha na criação de usuário lojista na base de dados",
                    Object = model,
                    Place = this.GetPlace()
                });
                throw new RepositoryException($"Falha na criação de usuário lojista na base de dados", ex);
            }
        }

        public async Task<List<UserStoreSmartHintDbModel>> GetAllAsync()
        {
            try
            {
                return
                    await _db.UsersStores
                             .AsNoTracking()
                             .ToListAsync();
            }
            catch (Exception ex)
            {
                _logsAppHelper.WriteError(new LogErrorVO
                {
                    Exception = ex,
                    Message = $"Falha na listagem de todos os usuários lojistas na base de dados",
                    Place = this.GetPlace()
                });
                throw new RepositoryException($"Falha na listagem de todos os usuários lojistas na base de dados", ex);
            }
        }

        public async Task<List<UserStoreSmartHintDbModel>> GetByFilterAsync(UsersStoresFilter filter)
        {
            try
            {
                return
                    await _db.UsersStores
                             .Where(x => 
                                (string.IsNullOrEmpty(filter.NameOrCorporateReason) || x.NameOrCorporateReason.ToUpper().Contains(filter.NameOrCorporateReason.Trim().ToUpper())) &&
                                (string.IsNullOrEmpty(filter.PhoneNumber) || x.PhoneNumber.ToUpper().Contains(filter.PhoneNumber.Trim().ToUpper())) &&
                                (string.IsNullOrEmpty(filter.Email) || x.Email.ToUpper().Contains(filter.Email.Trim().ToUpper())) &&
                                (string.IsNullOrEmpty(filter.PersonType) || x.PersonType.ToUpper().Contains(filter.PersonType.Trim().ToUpper())) &&
                                (string.IsNullOrEmpty(filter.CpfCnpj) || x.CpfCnpj.Contains(filter.CpfCnpj.Trim())) &&
                                (string.IsNullOrEmpty(filter.StateRegistration) || x.StateRegistration.Contains(filter.StateRegistration.Trim())) &&
                                (filter.IsBlocked == null || x.IsBlocked == filter.IsBlocked))
                             .AsNoTracking()
                             .ToListAsync();
            }
            catch (Exception ex)
            {
                _logsAppHelper.WriteError(new LogErrorVO
                {
                    Exception = ex,
                    Message = $"Falha na listagem de usuário lojista por filtros",
                    Object = filter,
                    Place = this.GetPlace()
                });
                throw new RepositoryException($"Falha na listagem de usuário lojista por filtros", ex);
            }
        }

        public async Task<UserStoreSmartHintDbModel> GetByIdAsync(int id)
        {
            try
            {
                return
                    await _db.UsersStores
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logsAppHelper.WriteError(new LogErrorVO
                {
                    Exception = ex,
                    Message = $"Falha na listagem de usuário lojista por id da base de dados",
                    Object = id,
                    Place = this.GetPlace()
                });
                throw new RepositoryException($"Falha na listagem de usuário lojista por id da base de dados", ex);
            }
        }

        public async Task RemoveAsync(Expression<Func<UserStoreSmartHintDbModel, bool>> query)
        {
            try
            {
                await _db.UsersStores.Where(query).ExecuteDeleteAsync();
            }
            catch (Exception ex)
            {
                _logsAppHelper.WriteError(new LogErrorVO
                {
                    Exception = ex,
                    Message = $"Falha na deleção de usuário lojista da base de dados",
                    Object = query.Body,
                    Place = this.GetPlace()
                });
                throw new RepositoryException($"Falha na deleção de usuário lojista da base de dados", ex);
            }
        }

        public async Task UpdateAsync(UserStoreSmartHintDbModel model)
        {
            try
            {
                var user = await _db.UsersStores.FirstOrDefaultAsync(x => x.Id == model.Id);

                if (user == null)
                    throw new NotFoundException($"Não foi encontrado um usuário lojista com o id {model.Id}");

                model.CreatedAt = user.CreatedAt;

                if (string.IsNullOrEmpty(model.PasswordHash))
                    model.PasswordHash = user.PasswordHash;

                _mapper.Map(model, user);

                await _db.SaveChangesAsync();
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logsAppHelper.WriteError(new LogErrorVO
                {
                    Exception = ex,
                    Message = $"Falha na atualização de usuário lojista da base de dados",
                    Object = model,
                    Place = this.GetPlace()
                });
                throw new RepositoryException($"Falha na atualização de usuário lojista da base de dados", ex);
            }
        }
    }
}
