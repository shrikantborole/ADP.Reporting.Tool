using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using ADP.Reporting.Tool.Models.Configurations;
using ADP.Reporting.Tool.Services;
using ADP.Reporting.Tool.Services.Interface;

namespace ADP.Reporting.Migration.Tool
{
    public static class DependencyResolver
    {
        public static IServiceProvider ConfigureServices(IConfiguration configuration)
        {
            var serviceCollection = new ServiceCollection();

            // Add logging
            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                loggingBuilder.AddNLog(configuration);
            });

            // Configure MigrationConfiguration using appsettings.json
            serviceCollection.Configure<MigrationConfiguration>(configuration.GetSection("MigrationConfiguration"));

            // Register your services
            ServiceExtensions.ConfigureServices(serviceCollection);

            return serviceCollection.BuildServiceProvider();
        }
    }
}
