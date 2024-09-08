using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.Services.Interface
{
    /// <summary>
    /// Defines the contract for SQL file data services.
    /// </summary>
    public interface ISqlFileDataService
    {
        /// <summary>
        /// Inserts a new SQL file data record asynchronously.
        /// </summary>
        /// <param name="sqlFileData">The SQL file data to insert.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of rows affected.</returns>
        Task<int> InsertSqlFileDataAsync(SqlFileData sqlFileData);

        /// <summary>
        /// Updates an existing SQL file data record asynchronously.
        /// </summary>
        /// <param name="sqlFileData">The SQL file data to update.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of rows affected.</returns>
        Task<int> UpdateSqlFileDataAsync(SqlFileData sqlFileData);

        /// <summary>
        /// Deletes an SQL file data record asynchronously by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the SQL file data to delete.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of rows affected.</returns>
        Task<int> DeleteSqlFileDataAsync(int id);

        /// <summary>
        /// Retrieves a list of SQL file data records asynchronously, with pagination.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a collection of SQL file data records.</returns>
        Task<IEnumerable<SqlFileData>> GetSqlFileDatasAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Retrieves an SQL file data record asynchronously by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the SQL file data to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the SQL file data if found, otherwise null.</returns>
        Task<SqlFileData> GetSqlFileDataByIdAsync(int id);

        /// <summary>
        /// Inserts or updates an SQL file data record asynchronously.
        /// </summary>
        /// <param name="sqlFileData">The SQL file data to insert or update.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the inserted or updated SQL file data.</returns>
        Task<SqlFileData> UpSertSqlFileDataAsync(SqlFileData sqlFileData);
    }
}
