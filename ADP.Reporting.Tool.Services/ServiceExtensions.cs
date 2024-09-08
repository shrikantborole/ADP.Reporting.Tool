using ADP.Reporting.Tool.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ADP.Reporting.Tool.Services
{
    /// <summary>
    /// Extension methods for configuring service dependencies.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configures services by registering them with the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection to configure.</param>
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Register repository services
            DataServices.ServiceExtensions.ConfigureRepositories(services);

            // Register application services
            services.AddScoped<IAlphabetService, AlphabetService>();
            services.AddScoped<IClientInformationService, ClientInformationService>();
            services.AddScoped<IReportTypeService, ReportTypeService>();
            services.AddScoped<IRequestInformationService, RequestInformationService>();
            services.AddScoped<ISqlFileDataService, SqlFileDataService>();
            services.AddScoped<IDataMigratorService, DataMigratorService>();
        }
    }
}
