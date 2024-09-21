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
    public class RequestInformationRepository : IRequestInformationRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<RequestInformationRepository> _logger;

        public RequestInformationRepository(IConfiguration configuration, ILogger<RequestInformationRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public async Task<int> InsertRequestInformationAsync(RequestInformation requestInformation)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@ClientId", requestInformation.ClientId);
                    parameters.Add("@RequestType", requestInformation.RequestType);
                    parameters.Add("@Description", requestInformation.Description);
                    parameters.Add("@CreatedDate", requestInformation.CreatedDate);
                    parameters.Add("@UpdatedDate", requestInformation.UpdatedDate);
                    parameters.Add("@CreatedBy", requestInformation.CreatedBy);
                    parameters.Add("@UpdatedBy", requestInformation.UpdatedBy);
                    parameters.Add("@ReportId", requestInformation.ReportId);

                    int rowsAffected = await db.ExecuteAsync("InsertRequestInformation", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Inserted RequestInformation with ClientId: {ClientId}. Rows affected: {RowsAffected}", requestInformation.ClientId, rowsAffected);
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error inserting RequestInformation with ClientId: {ClientId}.", requestInformation.ClientId);
                throw;
            }
        }

        public async Task<int> UpdateRequestInformationAsync(RequestInformation requestInformation)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", requestInformation.Id);
                    parameters.Add("@ClientId", requestInformation.ClientId);
                    parameters.Add("@RequestType", requestInformation.RequestType);
                    parameters.Add("@Description", requestInformation.Description);
                    parameters.Add("@UpdatedDate", requestInformation.UpdatedDate);
                    parameters.Add("@UpdatedBy", requestInformation.UpdatedBy);
                    parameters.Add("@ReportId", requestInformation.ReportId);

                    int rowsAffected = await db.ExecuteAsync("UpdateRequestInformation", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Updated RequestInformation with Id: {Id}. Rows affected: {RowsAffected}", requestInformation.Id, rowsAffected);
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error updating RequestInformation with Id: {Id}.", requestInformation.Id);
                throw;
            }
        }

        public async Task<int> DeleteRequestInformationAsync(int id)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);

                    int rowsAffected = await db.ExecuteAsync("DeleteRequestInformation", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Deleted RequestInformation with Id: {Id}. Rows affected: {RowsAffected}", id, rowsAffected);
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error deleting RequestInformation with Id: {Id}.", id);
                throw;
            }
        }

        public async Task<IEnumerable<RequestInformation>> GetRequestInformationsAsync(int pageIndex, int pageSize)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@PageNumber", pageIndex);
                    parameters.Add("@PageSize", pageSize);

                    var result = await db.QueryAsync<RequestInformation>("GetAllRequestInformations", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Retrieved {Count} RequestInformation records for page {PageIndex} with page size {PageSize}.", result.AsList().Count, pageIndex, pageSize);
                    return result;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error retrieving RequestInformation for page {PageIndex} with page size {PageSize}.", pageIndex, pageSize);
                throw;
            }
        }

        public async Task<RequestInformation> GetRequestInformationByIdAsync(int id)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);

                    var result = await db.QuerySingleOrDefaultAsync<RequestInformation>("GetRequestInformationById", parameters, commandType: CommandType.StoredProcedure);
                    if (result != null)
                    {
                        _logger.LogInformation("Retrieved RequestInformation with Id: {Id}.", id);
                    }
                    else
                    {
                        _logger.LogWarning("No RequestInformation found with Id: {Id}.", id);
                    }
                    return result;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error retrieving RequestInformation with Id: {Id}.", id);
                throw;
            }
        }

        public async Task<RequestInformation> UpsertRequestInformationAsync(RequestInformation requestInformation)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@ClientId", requestInformation.ClientId);
                    parameters.Add("@RequestType", requestInformation.RequestType);
                    parameters.Add("@Description", requestInformation.Description);
                    parameters.Add("@CreatedDate", requestInformation.CreatedDate);
                    parameters.Add("@UpdatedDate", requestInformation.UpdatedDate);
                    parameters.Add("@CreatedBy", requestInformation.CreatedBy);
                    parameters.Add("@UpdatedBy", requestInformation.UpdatedBy);
                    parameters.Add("@ReportId", requestInformation.ReportId);

                    var result = await db.QueryFirstOrDefaultAsync<RequestInformation>("UpSertRequestInformation", parameters, commandType: CommandType.StoredProcedure);
                    if (result != null)
                    {
                        _logger.LogInformation("UpSerted RequestInformation with ClientId: {ClientId}.", requestInformation.ClientId);
                    }
                    else
                    {
                        _logger.LogWarning("No RequestInformation returned after UpSert with ClientId: {ClientId}.", requestInformation.ClientId);
                    }
                    return result;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error UpSerting RequestInformation with ClientId: {ClientId}.", requestInformation.ClientId);
                throw;
            }
        }
    }
}
