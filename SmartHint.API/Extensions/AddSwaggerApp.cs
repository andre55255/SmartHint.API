using Microsoft.OpenApi.Models;
using SmartHint.Lib.Utils.Helpers;
using System.Reflection;

namespace SmartHint.API.Extensions
{
    public static class AddSwaggerApp
    {
        public static IServiceCollection AddSwaggerGeneration(this IServiceCollection services, IConfiguration configuration)
        {
            string version = configuration[ConfigAppSettings.VersionApi];

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc($"v{version}", new OpenApiInfo
                {
                    Title = "SmartHint.API",
                    Version = $"Versão {version}",
                    Description = $"API Smart Hint <br/> RELEASE {version}",
                    Contact = new OpenApiContact
                    {
                        Email = "andre_luiz.b5@outlook.com",
                        Name = "SmartHint.API"
                    }
                });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                if (!File.Exists(xmlPath))
                    File.Create(xmlPath);

                opt.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
