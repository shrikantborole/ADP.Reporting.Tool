using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.Services.Interface
{
    /// <summary>
    /// Defines the contract for report type services.
    /// </summary>
    public interface IReportTypeService
    {
        /// <summary>
        /// Inserts a new report type asynchronously.
        /// </summary>
        /// <param name="reportType">The report type to insert.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of rows affected.</returns>
        Task<int> InsertReportTypeAsync(ReportType reportType);

        /// <summary>
        /// Updates an existing report type asynchronously.
        /// </summary>
        /// <param name="reportType">The report type to update.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of rows affected.</returns>
        Task<int> UpdateReportTypeAsync(ReportType reportType);

        /// <summary>
        /// Deletes a report type asynchronously by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the report type to delete.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of rows affected.</returns>
        Task<int> DeleteReportTypeAsync(int id);

        /// <summary>
        /// Retrieves a list of report types asynchronously, with pagination.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a collection of report types.</returns>
        Task<IEnumerable<ReportType>> GetReportTypesAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Retrieves a report type asynchronously by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the report type to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the report type if found, otherwise null.</returns>
        Task<ReportType> GetReportTypeByIdAsync(int id);

        /// <summary>
        /// Inserts or updates a report type asynchronously.
        /// </summary>
        /// <param name="reportType">The report type to insert or update.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the inserted or updated report type.</returns>
        Task<ReportType> UpSertReportTypeAsync(ReportType reportType);
    }
}
