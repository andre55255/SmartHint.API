using SmartHint.Lib.Repositories;

namespace SmartHint.API.Extensions
{
    public static class AddRepositoriesApp
    {
        public static IServiceCollection AddRepositoriesContainerDIApp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositoriesApp(configuration);

            return services;
        }
    }
}
