namespace SmartHint.Api.Middlewares
{
    public static class RedirectRootToSwaggerMiddleware
    {
        public static IApplicationBuilder UseRedirectRootToSwagger(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/swagger");
                    return;
                }

                await next();
            });
            return app;
        }
    }
}
