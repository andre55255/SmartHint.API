using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartHint.Lib.Repositories.SmartHintDB.Config.Context;
using SmartHint.Lib.Repositories.SmartHintDB.Repository.Configurations;
using SmartHint.Lib.Repositories.SmartHintDB.Repository.UsersStores;
using SmartHint.Lib.Utils.Helpers;

namespace SmartHint.Lib.Repositories.SmartHintDB.Repository
{
    public static class _RepositoriesSmartHintDBContainerDIModule
    {
        public static IServiceCollection AddRepostoriesSmartHintDBApp(this IServiceCollection services, IConfiguration configuration)
        {
            // Contexts Configs
            var connStr = configuration.GetConnectionString(ConfigAppSettings.ConnectionStringSmartHintDB);

            services.AddDbContext<SmartHintDbContext>(opt =>
            {
                opt.UseMySql(connStr, ServerVersion.AutoDetect(connStr), x =>
                {
                    x.MigrationsAssembly("SmartHint.API");
                    x.EnableRetryOnFailure();
                });
            });

            // Repositories Configs
            services.AddScoped<IConfigurationsSmartHintDbRepository, ConfigurationsSmartHintDbRepository>();
            services.AddScoped<IUsersStoresSmartHintDbRepository, UsersStoresSmartHintDbRepository>();

            return services;
        }
    }
}
