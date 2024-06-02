using ADP.Reporting.Tool.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ADP.Reporting.Tool.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Register your services here
            services.AddScoped<IAlphabetService, AlphabetService>();
            services.AddScoped<IClientInformationService, ClientInformationService>();
            services.AddScoped<IReportTypeService, ReportTypeService>();
            services.AddScoped<IRequestInformationService, RequestInformationService>();
            services.AddScoped<ISqlFileDataService, SqlFileDataService>();
        }
    }
}
