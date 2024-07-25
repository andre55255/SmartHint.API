using SmartHint.Lib.Services.Services;

namespace SmartHint.API.Extensions
{
    public static class AddServicesApp
    {
        public static IServiceCollection AddServicesContainerDIApp(this IServiceCollection services)
        {
            services.AddServicesContainerDIModuleApp();

            return services;
        }
    }
}
