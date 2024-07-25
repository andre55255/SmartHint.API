using Microsoft.Extensions.DependencyInjection;
using SmartHint.Lib.Utils.Helpers.LogsApp;

namespace SmartHint.Lib.Utils
{
    public static class _UtilsContainerDIModule
    {
        public static IServiceCollection AddUtilsContainerDIModuleApp(this IServiceCollection services)
        {
            services.AddScoped<ILogsAppHelper, LogsAppHelper>();

            return services;
        }
    }
}
