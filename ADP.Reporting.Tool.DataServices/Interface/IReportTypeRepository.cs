using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.DataServices.Interface
{
    public interface IReportTypeRepository
    {
        Task<int> InsertReportTypeAsync(ReportType reportType);
        Task<int> UpdateReportTypeAsync(ReportType reportType);
        Task<int> DeleteReportTypeAsync(int id);
        Task<IEnumerable<ReportType>> GetReportTypesAsync(int pageIndex, int pageSize);
        Task<ReportType> GetReportTypeByIdAsync(int id);
    }
}
