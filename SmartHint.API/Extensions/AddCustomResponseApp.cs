using SmartHint.Lib.Models.ViewObjects.Utils;
using Microsoft.AspNetCore.Mvc;

namespace SmartHint.Api.Extensions
{
    public static class AddCustomResponseApp
    {
        public static IMvcBuilder AddCustomResponse(this IMvcBuilder builder)
        {
            builder.ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var response = new APIResponseVO
                    {
                        Success = false,
                    };
                    foreach (var (key, value) in context.ModelState)
                    {
                        response.Message = value.Errors.Select(x => x.ErrorMessage).FirstOrDefault();
                    }
                    return new BadRequestObjectResult(response);
                };
            });
            return builder;
        }
    }
}
