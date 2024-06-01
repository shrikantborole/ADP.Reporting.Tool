using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.Services.Interface
{
    public interface IReportTypeService
    {
        Task<int> InsertReportTypeAsync(ReportType reportType);
        Task<int> UpdateReportTypeAsync(ReportType reportType);
        Task<int> DeleteReportTypeAsync(int id);
        Task<IEnumerable<ReportType>> GetReportTypesAsync(int pageNumber, int pageSize);
        Task<ReportType> GetReportTypeByIdAsync(int id);
    }
}
