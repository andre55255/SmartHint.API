using Microsoft.Extensions.DependencyInjection;
using SmartHint.Lib.Services.Profiles;
using SmartHint.Lib.Services.Services.Configurations;
using SmartHint.Lib.Services.Services.UsersStores;
using SmartHint.Lib.Utils;

namespace SmartHint.Lib.Services.Services
{
    public static class _ServicesContainerDIModule
    {
        public static IServiceCollection AddServicesContainerDIModuleApp(this IServiceCollection services)
        {
            services.AddAutoMapperApp();
            services.AddUtilsContainerDIModuleApp();

            services.AddScoped<IConfigurationsService, ConfigurationsService>();
            services.AddScoped<IUsersStoresService, UsersStoresService>();

            return services;
        }
    }
}
