using AutoMapper;
using SmartHint.Lib.Models.DbEntities.SmartHintDB;
using SmartHint.Lib.Models.Inputs.UsersStores;
using SmartHint.Lib.Models.ViewObjects.UsersStores;

namespace SmartHint.Lib.Services.Profiles.UsersStores
{
    public class UsersStoresProfile : Profile
    {
        public UsersStoresProfile()
        {
            CreateMap<UserStoreSmartHintDbModel, UserStoreSmartHintDbModel>()
                .ReverseMap();

            CreateMap<UserStoreSmartHintDbModel, UsersStoresGetVO>();

            CreateMap<SaveUsersStoresInputVO, UserStoreSmartHintDbModel>();
        }
    }
}
