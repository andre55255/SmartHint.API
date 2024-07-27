using AutoMapper;
using SmartHint.Lib.Models.DbEntities.SmartHintDB;
using SmartHint.Lib.Models.Filters.UsersStores;
using SmartHint.Lib.Models.Inputs.UsersStores;
using SmartHint.Lib.Models.ViewObjects.Logs;
using SmartHint.Lib.Models.ViewObjects.UsersStores;
using SmartHint.Lib.Repositories.SmartHintDB.Repository.UsersStores;
using SmartHint.Lib.Services.Services.Configurations;
using SmartHint.Lib.Utils.CustomExceptions;
using SmartHint.Lib.Utils.Helpers;
using SmartHint.Lib.Utils.Helpers.LogsApp;

namespace SmartHint.Lib.Services.Services.UsersStores
{
    public class UsersStoresService : IUsersStoresService
    {
        private readonly IConfigurationsService _configurationsService;
        private readonly IUsersStoresSmartHintDbRepository _usersStoresSmartHintDbRepo;
        private readonly ILogsAppHelper _logsAppHelper;
        private readonly IMapper _mapper;

        public UsersStoresService(IConfigurationsService configurationsService, IUsersStoresSmartHintDbRepository usersStoresSmartHintDbRepo, ILogsAppHelper logsAppHelper, IMapper mapper)
        {
            _configurationsService = configurationsService;
            _usersStoresSmartHintDbRepo = usersStoresSmartHintDbRepo;
            _logsAppHelper = logsAppHelper;
            _mapper = mapper;
        }

        public async Task CreateAsync(SaveUsersStoresInputVO model)
        {
            try
            {
                await ValidConsistencyData(model);

                var countUsersWithEmail = await _usersStoresSmartHintDbRepo.CountByQueryAsync(x => x.Email == model.Email);

                if (countUsersWithEmail > 0)
                    throw new ConflicException($"Email já está vinculado com outro comprador");

                var countUsersWithCpfCnpj = await _usersStoresSmartHintDbRepo.CountByQueryAsync(x => x.CpfCnpj == model.CpfCnpj);

                if (countUsersWithCpfCnpj > 0)
                    throw new ConflicException($"Cpf Cnpj já está vinculado com outro comprador");

                if (!string.IsNullOrEmpty(model.StateRegistration))
                {
                    var countusersWithIE = await _usersStoresSmartHintDbRepo.CountByQueryAsync(x => x.StateRegistration == model.StateRegistration);

                    if (countusersWithIE > 0)
                        throw new ConflicException($"Inscrição estadual informada já está vinculada com outro comprador");
                }


                if (string.IsNullOrEmpty(model.Password))
                    throw new ServiceException($"Senha de comprador não informada");

                var entity = _mapper.Map<UserStoreSmartHintDbModel>(model);

                entity.PasswordHash = CryptoMethodsHelper.GetMD5Hash(model.Password);

                await _usersStoresSmartHintDbRepo.CreateAsync(entity);
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
                    Message = $"Falha inesperada ao criar comprador",
                    Place = this.GetPlace(),
                    Object = model
                });
                throw new ServiceException($"Falha inesperada ao criar comprador", ex);
            }
        }

        public async Task<List<UsersStoresGetVO>> GetAllAsync()
        {
            try
            {
                var data = await _usersStoresSmartHintDbRepo.GetAllAsync();

                if (data == null || data.Count <= 0)
                    return new();

                return _mapper.Map<List<UsersStoresGetVO>>(data);
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
                    Message = $"Falha inesperada ao listar compradores",
                    Place = this.GetPlace(),
                });
                throw new ServiceException($"Falha inesperada ao listar compradores", ex);
            }
        }

        public async Task<List<UsersStoresGetVO>> GetByFilterAsync(UsersStoresFilter filter)
        {
            try
            {
                if (filter == null)
                    filter = new();

                var data = await _usersStoresSmartHintDbRepo.GetByFilterAsync(filter);

                if (data == null || data.Count <= 0)
                    return new();

                return _mapper.Map<List<UsersStoresGetVO>>(data);
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
                    Message = $"Falha inesperada ao listar compradores",
                    Place = this.GetPlace(),
                });
                throw new ServiceException($"Falha inesperada ao listar compradores", ex);
            }
        }

        public async Task<UsersStoresGetVO> GetByIdAsync(int id)
        {
            try
            {
                var data = await _usersStoresSmartHintDbRepo.GetByIdAsync(id);

                if (data == null)
                    throw new NotFoundException($"Não foi encontrado um comprador com o id {id}");

                return _mapper.Map<UsersStoresGetVO>(data);
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
                    Message = $"Falha inesperada ao listar comprador pelo id",
                    Place = this.GetPlace(),
                    Object = id,
                });
                throw new ServiceException($"Falha inesperada ao listar comprador pelo id", ex);
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var countUsersStoreWithId = await _usersStoresSmartHintDbRepo.CountByQueryAsync(x => x.Id == id);

                if (countUsersStoreWithId <= 0)
                    throw new NotFoundException($"Não foi encontrado um comprador com o id {id}");

                await _usersStoresSmartHintDbRepo.RemoveAsync(x => x.Id == id);
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
                    Message = $"Falha inesperada ao remover comprador pelo id",
                    Place = this.GetPlace(),
                    Object = id,
                });
                throw new ServiceException($"Falha inesperada ao remover comprador pelo id", ex);
            }
        }

        public async Task UpdateAsync(int id, SaveUsersStoresInputVO model)
        {
            try
            {
                await ValidConsistencyData(model);

                var countUsersWithEmail = await _usersStoresSmartHintDbRepo.CountByQueryAsync(x => x.Email == model.Email && x.Id != id);

                if (countUsersWithEmail > 0)
                    throw new ConflicException($"Email já está vinculado com outro comprador");

                var countUsersWithCpfCnpj = await _usersStoresSmartHintDbRepo.CountByQueryAsync(x => x.CpfCnpj == model.CpfCnpj && x.Id != id);

                if (countUsersWithCpfCnpj > 0)
                    throw new ConflicException($"Cpf Cnpj já está vinculado com outro comprador");

                if (!string.IsNullOrEmpty(model.StateRegistration))
                {
                    var countusersWithIE = await _usersStoresSmartHintDbRepo.CountByQueryAsync(x => x.StateRegistration == model.StateRegistration && x.Id != id);

                    if (countusersWithIE > 0)
                        throw new ConflicException($"Inscrição estadual informada já está vinculada com outro comprador");

                }
                var entity = _mapper.Map<UserStoreSmartHintDbModel>(model);
                entity.Id = id;

                if (!string.IsNullOrEmpty(model.Password))
                    entity.PasswordHash = CryptoMethodsHelper.GetMD5Hash(model.Password);

                await _usersStoresSmartHintDbRepo.UpdateAsync(entity);
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
                    Message = $"Falha inesperada ao atualizar comprador",
                    Place = this.GetPlace(),
                    Object = new { id, model }
                });
                throw new ServiceException($"Falha inesperada ao atualizar comprador", ex);
            }
        }

        private async Task ValidConsistencyData(SaveUsersStoresInputVO model)
        {
            var personTypesValid = new string[] { "F", "J" };

            if (!personTypesValid.Contains(model.PersonType))
                throw new ServiceException($"Tipo de pessoa informado inválido. Valores válidos: {string.Join(',', personTypesValid)}");

            if (model.PersonType == "F")
            {
                var gendersValid = new string[] { "F", "M", "O" };

                if (!gendersValid.Contains(model.Gender))
                    throw new ServiceException($"Gênero informado inválido. Valores válidos: {string.Join(',', gendersValid)}");

                if (model.BirthDate == null || model.BirthDate.Value > DateTime.Now.Date)
                    throw new ServiceException($"Data de nascimento de PF não informado ou inválida");
            }
            else
            {
                model.Gender = null;
                model.BirthDate = null;
            }

            if (model.IsExempt)
                model.StateRegistration = null;

            var isExemptConfig = await _configurationsService.IsStateRegistrationForPFAsync();

            if (model.PersonType == "F" && isExemptConfig && !model.IsExempt && string.IsNullOrEmpty(model.StateRegistration))
                throw new ServiceException($"Inscrição Estadual está configurada ser informada caso não seja isento em PF");

            if (model.PersonType == "J" && !model.IsExempt && string.IsNullOrEmpty(model.StateRegistration))
                throw new ServiceException($"Incrição Estadual deve ser informada caso não seja isento");
        }
    }
}
