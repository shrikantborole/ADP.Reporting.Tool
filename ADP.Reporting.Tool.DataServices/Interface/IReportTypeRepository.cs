using ADP.Reporting.Tool.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADP.Reporting.Tool.DataServices.Interface
{
    /// <summary>
    /// Defines methods for managing report types.
    /// </summary>
    public interface IReportTypeRepository
    {
        /// <summary>
        /// Inserts a new report type record.
        /// </summary>
        /// <param name="reportType">The report type to insert.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> InsertReportTypeAsync(ReportType reportType);

        /// <summary>
        /// Updates an existing report type record.
        /// </summary>
        /// <param name="reportType">The report type to update.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> UpdateReportTypeAsync(ReportType reportType);

        /// <summary>
        /// Deletes a report type record by its ID.
        /// </summary>
        /// <param name="id">The ID of the report type to delete.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> DeleteReportTypeAsync(int id);

        /// <summary>
        /// Retrieves report types with pagination support.
        /// </summary>
        /// <param name="pageIndex">The page index for pagination.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A collection of report types.</returns>
        Task<IEnumerable<ReportType>> GetReportTypesAsync(int pageIndex, int pageSize);

        /// <summary>
        /// Retrieves a report type by its ID.
        /// </summary>
        /// <param name="id">The ID of the report type to retrieve.</param>
        /// <returns>The report type with the specified ID.</returns>
        Task<ReportType> GetReportTypeByIdAsync(int id);

        /// <summary>
        /// Inserts or updates a report type.
        /// </summary>
        /// <param name="reportType">The report type to insert or update.</param>
        /// <returns>The inserted or updated report type.</returns>
        Task<ReportType> UpsertReportTypeAsync(ReportType reportType);
    }
}
