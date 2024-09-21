using ADP.Reporting.Tool.Models.Configurations;
using ADP.Reporting.Tool.Services;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Configure NLog to use nlog.config
        var logger = LogManager.Setup()
                               .LoadConfigurationFromFile("nlog.config")
                               .GetCurrentClassLogger();

        try
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var serviceCollection = new ServiceCollection();

            // Add configuration and logging services
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                loggingBuilder.AddNLog($"{AppDomain.CurrentDomain.BaseDirectory}/nlog.config");
            });

            // Register application services
            ServiceExtensions.ConfigureServices(serviceCollection);
            serviceCollection.Configure<MigrationConfiguration>(configuration.GetSection("Migration"));

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Execute data migration if the service is available
            var dataMigratorService = serviceProvider.GetService<IDataMigratorService>();
            if (dataMigratorService != null)
            {
                await dataMigratorService.Run();
            }
        }
        catch (Exception ex)
        {
            // NLog: catch any exception and log it
            logger.Error(ex, "Stopped program because of an exception.");
            throw;
        }
        finally
        {
            // Ensure to flush and stop internal timers/threads before application-exit
            LogManager.Shutdown();
        }
    }
}
