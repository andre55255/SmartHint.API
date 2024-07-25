using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SmartHint.Lib.Repositories.SmartHintDB.Repository
{
    public static class _RepositoriesSmartHintDBContainerDIModule
    {
        public static IServiceCollection AddRepostoriesSmartHintDBApp(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
