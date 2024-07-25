using SmartHint.Api.Extensions;
using SmartHint.API.Extensions;
using SmartHint.Api.Middlewares;
using SmartHint.Lib.Utils.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//// Configs services
// Add Controllers
builder.Services.AddControllers().AddCustomResponse();

// Config Endpoints
builder.Services.AddEndpointsApiExplorer();

// Add Cors
builder.Services.AddCors();

// Add Repositories
builder.Services.AddRepositoriesContainerDIApp(builder.Configuration);

// Add Services
builder.Services.AddServicesContainerDIApp();

// Add Swagger
builder.Services.AddSwaggerGeneration(builder.Configuration);

var app = builder.Build();

// Configure is Dev
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

// Config Swagger page
app.UseSwagger()
   .UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/v{builder.Configuration[ConfigAppSettings.VersionApi]}/swagger.json", "SmartHint.API"));

// Config Reverse Proxy Nginx
app.UseForwardedHeaders();

// Config cors
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Middleware redirect
app.UseRedirectRootToSwagger();

app.MapControllers();

app.Run();
