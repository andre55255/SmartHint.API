using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartHint.Lib.Repositories.SmartHintDB.Repository;

namespace SmartHint.Lib.Repositories
{
    public static class _RepositoriesContainerDIModule
    {
        public static IServiceCollection AddRepositoriesApp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepostoriesSmartHintDBApp(configuration);

            return services;
        }
    }
}
