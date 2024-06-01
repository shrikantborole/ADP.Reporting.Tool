using ADP.Reporting.Tool.DataServices.Interface;
using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;

namespace ADP.Reporting.Tool.Services
{
    public class ReportTypeService : IReportTypeService
    {
        private readonly IReportTypeRepository _reportTypeRepository;

        public ReportTypeService(IReportTypeRepository reportTypeRepository)
        {
            _reportTypeRepository = reportTypeRepository;
        }

        public async Task<int> InsertReportTypeAsync(ReportType reportType)
        {
            return await _reportTypeRepository.InsertReportTypeAsync(reportType);
        }

        public async Task<int> UpdateReportTypeAsync(ReportType reportType)
        {
            return await _reportTypeRepository.UpdateReportTypeAsync(reportType);
        }

        public async Task<int> DeleteReportTypeAsync(int id)
        {
            return await _reportTypeRepository.DeleteReportTypeAsync(id);
        }

        public async Task<IEnumerable<ReportType>> GetReportTypesAsync(int pageIndex, int pageSize)
        {
            return await _reportTypeRepository.GetReportTypesAsync(pageIndex, pageSize);
        }

        public async Task<ReportType> GetReportTypeByIdAsync(int id)
        {
            return await _reportTypeRepository.GetReportTypeByIdAsync(id);
        }
    }
}
