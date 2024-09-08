using ADP.Reporting.Tool.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADP.Reporting.Tool.DataServices.Interface
{
    /// <summary>
    /// Defines methods for managing SQL file data records.
    /// </summary>
    public interface ISqlFileDataRepository
    {
        /// <summary>
        /// Inserts a new SQL file data record.
        /// </summary>
        /// <param name="sqlFileData">The SQL file data to insert.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> InsertSqlFileDataAsync(SqlFileData sqlFileData);

        /// <summary>
        /// Updates an existing SQL file data record.
        /// </summary>
        /// <param name="sqlFileData">The SQL file data to update.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> UpdateSqlFileDataAsync(SqlFileData sqlFileData);

        /// <summary>
        /// Deletes a SQL file data record by its ID.
        /// </summary>
        /// <param name="id">The ID of the SQL file data to delete.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> DeleteSqlFileDataAsync(int id);

        /// <summary>
        /// Retrieves SQL file data records with pagination support.
        /// </summary>
        /// <param name="pageIndex">The page index for pagination.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A collection of SQL file data records.</returns>
        Task<IEnumerable<SqlFileData>> GetSqlFileDatasAsync(int pageIndex, int pageSize);

        /// <summary>
        /// Retrieves a SQL file data record by its ID.
        /// </summary>
        /// <param name="id">The ID of the SQL file data to retrieve.</param>
        /// <returns>The SQL file data with the specified ID.</returns>
        Task<SqlFileData> GetSqlFileDataByIdAsync(int id);

        /// <summary>
        /// Inserts or updates a SQL file data record.
        /// </summary>
        /// <param name="sqlFileData">The SQL file data to insert or update.</param>
        /// <returns>The inserted or updated SQL file data.</returns>
        Task<SqlFileData> UpsertSqlFileDataAsync(SqlFileData sqlFileData);
    }
}
