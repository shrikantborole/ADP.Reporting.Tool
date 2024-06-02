using ADP.Reporting.Tool.DataServices.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP.Reporting.Tool.DataServices
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            // Register your repositories here
            services.AddScoped<IAlphabetRepository, AlphabetRepository>();
            services.AddScoped<IClientInformationRepository, ClientInformationRepository>();
            services.AddScoped<IReportTypeRepository, ReportTypeRepository>();
            services.AddScoped<IRequestInformationRepository, RequestInformationRepository>();
            services.AddScoped<ISqlFileDataRepository, SqlFileDataRepository>();
        }
    }
}
