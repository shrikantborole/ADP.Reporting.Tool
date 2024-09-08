using ADP.Reporting.Tool.DataServices.Interface;
using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.Extensions.Logging;

namespace ADP.Reporting.Tool.Services
{
    /// <summary>
    /// Provides services for managing SQL file data.
    /// </summary>
    public class SqlFileDataService : ISqlFileDataService
    {
        private readonly ISqlFileDataRepository _sqlFileDataRepository;
        private readonly ILogger<SqlFileDataService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlFileDataService"/> class.
        /// </summary>
        /// <param name="sqlFileDataRepository">The repository to interact with SQL file data.</param>
        /// <param name="logger">The logger to log information and errors.</param>
        public SqlFileDataService(ISqlFileDataRepository sqlFileDataRepository, ILogger<SqlFileDataService> logger)
        {
            _sqlFileDataRepository = sqlFileDataRepository;
            _logger = logger;
        }

        /// <summary>
        /// Inserts a new SQL file data record.
        /// </summary>
        /// <param name="sqlFileData">The SQL file data to insert.</param>
        /// <returns>The number of records affected.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public async Task<int> InsertSqlFileDataAsync(SqlFileData sqlFileData)
        {
            try
            {
                return await _sqlFileDataRepository.InsertSqlFileDataAsync(sqlFileData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting SQL file data with RequestId: {RequestId}", sqlFileData.RequestId);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing SQL file data record.
        /// </summary>
        /// <param name="sqlFileData">The SQL file data to update.</param>
        /// <returns>The number of records affected.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public async Task<int> UpdateSqlFileDataAsync(SqlFileData sqlFileData)
        {
            try
            {
                return await _sqlFileDataRepository.UpdateSqlFileDataAsync(sqlFileData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating SQL file data with Id: {Id}", sqlFileData.Id);
                throw;
            }
        }

        /// <summary>
        /// Deletes a SQL file data record by its ID.
        /// </summary>
        /// <param name="id">The ID of the SQL file data record to delete.</param>
        /// <returns>The number of records affected.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public async Task<int> DeleteSqlFileDataAsync(int id)
        {
            try
            {
                return await _sqlFileDataRepository.DeleteSqlFileDataAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting SQL file data with Id: {Id}", id);
                throw;
            }
        }

        /// <summary>
        /// Retrieves a list of SQL file data records with pagination.
        /// </summary>
        /// <param name="pageIndex">The page index for pagination.</param>
        /// <param name="pageSize">The page size for pagination.</param>
        /// <returns>A collection of SQL file data records.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public async Task<IEnumerable<SqlFileData>> GetSqlFileDatasAsync(int pageIndex, int pageSize)
        {
            try
            {
                return await _sqlFileDataRepository.GetSqlFileDatasAsync(pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving SQL file data records. PageIndex: {PageIndex}, PageSize: {PageSize}", pageIndex, pageSize);
                throw;
            }
        }

        /// <summary>
        /// Retrieves a SQL file data record by its ID.
        /// </summary>
        /// <param name="id">The ID of the SQL file data record.</param>
        /// <returns>The SQL file data record.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public async Task<SqlFileData> GetSqlFileDataByIdAsync(int id)
        {
            try
            {
                return await _sqlFileDataRepository.GetSqlFileDataByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving SQL file data with Id: {Id}", id);
                throw;
            }
        }

        /// <summary>
        /// Inserts or updates a SQL file data record.
        /// </summary>
        /// <param name="sqlFileData">The SQL file data to insert or update.</param>
        /// <returns>The SQL file data record that was inserted or updated.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public async Task<SqlFileData> UpSertSqlFileDataAsync(SqlFileData sqlFileData)
        {
            try
            {
                return await _sqlFileDataRepository.UpsertSqlFileDataAsync(sqlFileData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error upserting SQL file data with RequestId: {RequestId}", sqlFileData.RequestId);
                throw;
            }
        }
    }
}
