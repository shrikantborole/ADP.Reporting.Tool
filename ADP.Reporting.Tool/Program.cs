using ADP.Reporting.Tool.Middleware;
using ADP.Reporting.Tool.Models.Configurations;
using ADP.Reporting.Tool.Services;
using NLog;
using NLog.Web;

// Early initialization of NLog to capture any setup errors
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("ADP.Reporting.Tool (Main) Started.");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // NLog: Setup NLog for Dependency Injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Add services to the container
    builder.Services.AddControllers();

    // Configure application services and repositories
    builder.Services.ConfigureServices();

    // Configure options for MigrationConfiguration
    builder.Services.AddOptions<MigrationConfiguration>()
        .Configure<IConfiguration>((options, config) =>
        {
            config.GetSection("Migration").Bind(options);
        });

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                   //WithOrigins("https://your-allowed-origin.com") // Allow specific origins
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .WithExposedHeaders("strict-origin-when-cross-origin");
        });
    });

    // Configure Swagger/OpenAPI
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    // Use CORS
    app.UseCors("CorsPolicy");

    // Register the custom exception handling middleware
    app.UseMiddleware<ExceptionHandlingMiddleware>();

    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped ADP.Reporting.Tool (Main) because of an exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application exit
    LogManager.Shutdown();
}
