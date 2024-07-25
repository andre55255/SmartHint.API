using SmartHint.Lib.Utils.Helpers;

namespace SmartHint.Api.Extensions
{
    public static class AddCorsApp
    {
        public static IServiceCollection AddCors(this IServiceCollection services, IConfiguration configuration)
        {
            string[] originsUrls = configuration.GetSection(ConfigAppSettings.ConfigCors)
                                                .Get<string[]>();

            services.AddCors(opt =>
            {
                opt.AddPolicy(ConfigPolicies.Cors, policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins(originsUrls)
                        .AllowCredentials();
                });
            });

            return services;
        }
    }
}
