using ADP.Reporting.Tool.DataServices.Interface;
using ADP.Reporting.Tool.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ADP.Reporting.Tool.DataServices
{
    public class ReportTypeRepository : IReportTypeRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<ReportTypeRepository> _logger;

        public ReportTypeRepository(IConfiguration configuration, ILogger<ReportTypeRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public async Task<int> InsertReportTypeAsync(ReportType reportType)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@ClientId", reportType.ClientId);
                    parameters.Add("@Type", reportType.Type);
                    parameters.Add("@Description", reportType.Description);
                    parameters.Add("@CreatedDate", reportType.CreatedDate);
                    parameters.Add("@UpdatedDate", reportType.UpdatedDate);
                    parameters.Add("@CreatedBy", reportType.CreatedBy);
                    parameters.Add("@UpdatedBy", reportType.UpdatedBy);

                    int rowsAffected = await db.ExecuteAsync("InsertReportType", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Inserted ReportType with Id: {ClientId}. Rows affected: {RowsAffected}", reportType.ClientId, rowsAffected);
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error inserting ReportType with ClientId: {ClientId}.", reportType.ClientId);
                throw;
            }
        }

        public async Task<int> UpdateReportTypeAsync(ReportType reportType)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", reportType.Id);
                    parameters.Add("@ClientId", reportType.ClientId);
                    parameters.Add("@Type", reportType.Type);
                    parameters.Add("@Description", reportType.Description);
                    parameters.Add("@UpdatedDate", reportType.UpdatedDate);
                    parameters.Add("@UpdatedBy", reportType.UpdatedBy);

                    int rowsAffected = await db.ExecuteAsync("UpdateReportType", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Updated ReportType with Id: {Id}. Rows affected: {RowsAffected}", reportType.Id, rowsAffected);
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error updating ReportType with Id: {Id}.", reportType.Id);
                throw;
            }
        }

        public async Task<int> DeleteReportTypeAsync(int id)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);

                    int rowsAffected = await db.ExecuteAsync("DeleteReportType", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Deleted ReportType with Id: {Id}. Rows affected: {RowsAffected}", id, rowsAffected);
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error deleting ReportType with Id: {Id}.", id);
                throw;
            }
        }

        public async Task<IEnumerable<ReportType>> GetReportTypesAsync(int pageIndex, int pageSize)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@PageNumber", pageIndex);
                    parameters.Add("@PageSize", pageSize);

                    var result = await db.QueryAsync<ReportType>("GetAllReportTypes", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Retrieved {Count} ReportType records for page {PageIndex} with page size {PageSize}.", result.AsList().Count, pageIndex, pageSize);
                    return result;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error retrieving ReportType records for page {PageIndex} with page size {PageSize}.", pageIndex, pageSize);
                throw;
            }
        }

        public async Task<ReportType> GetReportTypeByIdAsync(int id)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);

                    var result = await db.QuerySingleOrDefaultAsync<ReportType>("GetReportTypeById", parameters, commandType: CommandType.StoredProcedure);
                    if (result != null)
                    {
                        _logger.LogInformation("Retrieved ReportType with Id: {Id}.", id);
                    }
                    else
                    {
                        _logger.LogWarning("No ReportType found with Id: {Id}.", id);
                    }
                    return result;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error retrieving ReportType with Id: {Id}.", id);
                throw;
            }
        }

        public async Task<ReportType> UpsertReportTypeAsync(ReportType reportType)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@ClientId", reportType.ClientId);
                    parameters.Add("@Type", reportType.Type);
                    parameters.Add("@Description", reportType.Description);
                    parameters.Add("@CreatedDate", reportType.CreatedDate);
                    parameters.Add("@UpdatedDate", reportType.UpdatedDate);
                    parameters.Add("@CreatedBy", reportType.CreatedBy);
                    parameters.Add("@UpdatedBy", reportType.UpdatedBy);

                    var result = await db.QueryFirstOrDefaultAsync<ReportType>("UpSertReportType", parameters, commandType: CommandType.StoredProcedure);
                    if (result != null)
                    {
                        _logger.LogInformation("UpSerted ReportType with Id: {ClientId}.", reportType.ClientId);
                    }
                    else
                    {
                        _logger.LogWarning("No ReportType returned after UpSert with Id: {ClientId}.", reportType.ClientId);
                    }
                    return result;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error UpSerting ReportType with Id: {ClientId}.", reportType.ClientId);
                throw;
            }
        }
    }
}
