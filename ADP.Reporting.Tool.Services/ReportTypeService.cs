using ADP.Reporting.Tool.DataServices.Interface;
using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADP.Reporting.Tool.Services
{
    /// <summary>
    /// Service for handling operations related to report types.
    /// </summary>
    public class ReportTypeService : IReportTypeService
    {
        private readonly IReportTypeRepository _reportTypeRepository;
        private readonly ILogger<ReportTypeService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportTypeService"/> class.
        /// </summary>
        /// <param name="reportTypeRepository">The repository used for report type operations.</param>
        /// <param name="logger">The logger used for logging information and errors.</param>
        public ReportTypeService(IReportTypeRepository reportTypeRepository, ILogger<ReportTypeService> logger)
        {
            _reportTypeRepository = reportTypeRepository;
            _logger = logger;
        }

        /// <summary>
        /// Inserts a new report type.
        /// </summary>
        /// <param name="reportType">The report type to insert.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the ID of the inserted report type.</returns>
        public async Task<int> InsertReportTypeAsync(ReportType reportType)
        {
            try
            {
                _logger.LogInformation($"Inserting report type: {reportType.Type}");
                return await _reportTypeRepository.InsertReportTypeAsync(reportType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while inserting report type: {reportType.Type}");
                throw;
            }
        }

        /// <summary>
        /// Updates an existing report type.
        /// </summary>
        /// <param name="reportType">The report type to update.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of affected rows.</returns>
        public async Task<int> UpdateReportTypeAsync(ReportType reportType)
        {
            try
            {
                _logger.LogInformation($"Updating report type: {reportType.Type} with ID: {reportType.Id}");
                return await _reportTypeRepository.UpdateReportTypeAsync(reportType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating report type with ID: {reportType.Id}");
                throw;
            }
        }

        /// <summary>
        /// Deletes a report type by its ID.
        /// </summary>
        /// <param name="id">The ID of the report type to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of affected rows.</returns>
        public async Task<int> DeleteReportTypeAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting report type with ID: {id}");
                return await _reportTypeRepository.DeleteReportTypeAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting report type with ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Retrieves a list of report types with pagination.
        /// </summary>
        /// <param name="pageIndex">The page index for pagination.</param>
        /// <param name="pageSize">The page size for pagination.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable list of report types.</returns>
        public async Task<IEnumerable<ReportType>> GetReportTypesAsync(int pageIndex, int pageSize)
        {
            try
            {
                _logger.LogInformation($"Retrieving report types with page index: {pageIndex} and page size: {pageSize}");
                return await _reportTypeRepository.GetReportTypesAsync(pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving report types with page index: {pageIndex} and page size: {pageSize}");
                throw;
            }
        }

        /// <summary>
        /// Retrieves a report type by its ID.
        /// </summary>
        /// <param name="id">The ID of the report type to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the report type with the specified ID.</returns>
        public async Task<ReportType> GetReportTypeByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Retrieving report type with ID: {id}");
                return await _reportTypeRepository.GetReportTypeByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving report type with ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Inserts or updates a report type.
        /// </summary>
        /// <param name="reportType">The report type to insert or update.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the inserted or updated report type.</returns>
        public async Task<ReportType> UpSertReportTypeAsync(ReportType reportType)
        {
            try
            {
                _logger.LogInformation($"UpSerting report type: {reportType.Type}");
                return await _reportTypeRepository.UpsertReportTypeAsync(reportType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while upserting report type: {reportType.Type}");
                throw;
            }
        }
    }
}
