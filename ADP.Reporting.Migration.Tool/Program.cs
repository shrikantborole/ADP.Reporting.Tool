using ADP.Reporting.Migration.Tool;
using ADP.Reporting.Tool.Models.Configurations;
using ADP.Reporting.Tool.Services;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Configure NLog to use nlog.config
        var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();

        try
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                loggingBuilder.AddNLog($"{AppDomain.CurrentDomain.BaseDirectory}/nlog.config");
            });
            
            // Register your services
            ServiceExtensions.ConfigureServices(serviceCollection);

            //serviceCollection.AddTransient<IDataMigratorService, DataMigratorService>();
            var serviceProvider = serviceCollection.BuildServiceProvider();


            var dataMigratorService = serviceProvider.GetService<IDataMigratorService>();
            if (dataMigratorService != null)
            {
                await dataMigratorService.Run();
            }
        }
        catch (Exception ex)
        {
            // NLog: catch any exception and log it.
            logger.Error(ex, "Stopped program because of an exception.");
            throw;
        }
        finally
        {
            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            LogManager.Shutdown();
        }
    }
}
