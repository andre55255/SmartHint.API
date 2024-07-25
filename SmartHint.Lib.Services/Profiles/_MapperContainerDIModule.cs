using Microsoft.Extensions.DependencyInjection;

namespace SmartHint.Lib.Services.Profiles
{
    public static class _MapperContainerDIModule
    {
        public static IServiceCollection AddAutoMapperApp(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
