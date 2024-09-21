using ADP.Reporting.Tool.DataServices.Interface;
using ADP.Reporting.Tool.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace ADP.Reporting.Tool.DataServices
{
    public class SqlFileDataRepository : ISqlFileDataRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<SqlFileDataRepository> _logger;

        public SqlFileDataRepository(IConfiguration configuration, ILogger<SqlFileDataRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public async Task<int> InsertSqlFileDataAsync(SqlFileData sqlFileData)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@RequestId", sqlFileData.RequestId);
                    parameters.Add("@Description", sqlFileData.Description);
                    parameters.Add("@SqlFileData", sqlFileData.SqlFileDataContent);
                    parameters.Add("@CreatedDate", sqlFileData.CreatedDate);
                    parameters.Add("@UpdatedDate", sqlFileData.UpdatedDate);
                    parameters.Add("@CreatedBy", sqlFileData.CreatedBy);
                    parameters.Add("@UpdatedBy", sqlFileData.UpdatedBy);

                    int rowsAffected = await db.ExecuteAsync("InsertSqlFileData", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Inserted SQL file data with RequestId: {RequestId}. Rows affected: {RowsAffected}", sqlFileData.RequestId, rowsAffected);
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error inserting SQL file data with RequestId: {RequestId}.", sqlFileData.RequestId);
                throw;
            }
        }

        public async Task<int> UpdateSqlFileDataAsync(SqlFileData sqlFileData)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", sqlFileData.Id);
                    parameters.Add("@RequestId", sqlFileData.RequestId);
                    parameters.Add("@Description", sqlFileData.Description);
                    parameters.Add("@SqlFileData", sqlFileData.SqlFileDataContent);
                    parameters.Add("@UpdatedDate", sqlFileData.UpdatedDate);
                    parameters.Add("@UpdatedBy", sqlFileData.UpdatedBy);

                    int rowsAffected = await db.ExecuteAsync("UpdateSqlFileData", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Updated SQL file data with Id: {Id}. Rows affected: {RowsAffected}", sqlFileData.Id, rowsAffected);
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error updating SQL file data with Id: {Id}.", sqlFileData.Id);
                throw;
            }
        }

        public async Task<int> DeleteSqlFileDataAsync(int id)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);

                    int rowsAffected = await db.ExecuteAsync("DeleteSqlFileData", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Deleted SQL file data with Id: {Id}. Rows affected: {RowsAffected}", id, rowsAffected);
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error deleting SQL file data with Id: {Id}.", id);
                throw;
            }
        }

        public async Task<IEnumerable<SqlFileData>> GetSqlFileDatasAsync(int pageNumber, int pageSize)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@PageNumber", pageNumber);
                    parameters.Add("@PageSize", pageSize);

                    var result = await db.QueryAsync<SqlFileData>("GetAllSqlFileDatas", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Retrieved {Count} SQL file data records for page {PageNumber} with page size {PageSize}.", result.Count(), pageNumber, pageSize);
                    return result;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error retrieving SQL file data for page {PageNumber} with page size {PageSize}.", pageNumber, pageSize);
                throw;
            }
        }

        public async Task<SqlFileData> GetSqlFileDataByIdAsync(int id)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);

                    var result = await db.QuerySingleOrDefaultAsync<SqlFileData>("GetSqlFileDataById", parameters, commandType: CommandType.StoredProcedure);
                    if (result != null)
                    {
                        _logger.LogInformation("Retrieved SQL file data with Id: {Id}.", id);
                    }
                    else
                    {
                        _logger.LogWarning("No SQL file data found with Id: {Id}.", id);
                    }
                    return result;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error retrieving SQL file data by Id: {Id}.", id);
                throw;
            }
        }

        public async Task<SqlFileData> UpsertSqlFileDataAsync(SqlFileData sqlFileData)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@RequestId", sqlFileData.RequestId);
                    parameters.Add("@Description", sqlFileData.Description);
                    parameters.Add("@SqlFileData", sqlFileData.SqlFileDataContent);
                    parameters.Add("@CreatedDate", sqlFileData.CreatedDate);
                    parameters.Add("@UpdatedDate", sqlFileData.UpdatedDate);
                    parameters.Add("@CreatedBy", sqlFileData.CreatedBy);
                    parameters.Add("@UpdatedBy", sqlFileData.UpdatedBy);

                    var result = await db.QueryFirstOrDefaultAsync<SqlFileData>("UpSertSqlFileData", parameters, commandType: CommandType.StoredProcedure);
                    if (result != null)
                    {
                        _logger.LogInformation("UpSerted SQL file data with RequestId: {RequestId}.", sqlFileData.RequestId);
                    }
                    else
                    {
                        _logger.LogWarning("No SQL file data returned after UpSert with RequestId: {RequestId}.", sqlFileData.RequestId);
                    }
                    return result;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error UpSerting SQL file data with RequestId: {RequestId}.", sqlFileData.RequestId);
                throw;
            }
        }
    }
}
