using Microsoft.Extensions.DependencyInjection;
using SmartHint.Lib.Services.Profiles;
using SmartHint.Lib.Utils;

namespace SmartHint.Lib.Services.Services
{
    public static class _ServicesContainerDIModule
    {
        public static IServiceCollection AddServicesContainerDIModuleApp(this IServiceCollection services)
        {
            services.AddAutoMapperApp();
            services.AddUtilsContainerDIModuleApp();



            return services;
        }
    }
}
