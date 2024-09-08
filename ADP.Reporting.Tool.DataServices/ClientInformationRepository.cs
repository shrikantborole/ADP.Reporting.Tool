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
    public class ClientInformationRepository : IClientInformationRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<ClientInformationRepository> _logger;

        public ClientInformationRepository(IConfiguration configuration, ILogger<ClientInformationRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public async Task<int> InsertClientInformationAsync(ClientInformation clientInformation)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@AlphabetId", clientInformation.AlphabetId);
                    parameters.Add("@Name", clientInformation.Name);
                    parameters.Add("@Description", clientInformation.Description);
                    parameters.Add("@CreatedDate", clientInformation.CreatedDate);
                    parameters.Add("@UpdatedDate", clientInformation.UpdatedDate);
                    parameters.Add("@CreatedBy", clientInformation.CreatedBy);
                    parameters.Add("@UpdatedBy", clientInformation.UpdatedBy);

                    int rowsAffected = await connection.ExecuteAsync("InsertClientInformation", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Inserted ClientInformation with AlphabetId: {AlphabetId}. Rows affected: {RowsAffected}", clientInformation.AlphabetId, rowsAffected);
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error inserting ClientInformation with AlphabetId: {AlphabetId}.", clientInformation.AlphabetId);
                throw;
            }
        }

        public async Task<int> UpdateClientInformationAsync(ClientInformation clientInformation)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", clientInformation.Id);
                    parameters.Add("@AlphabetId", clientInformation.AlphabetId);
                    parameters.Add("@Name", clientInformation.Name);
                    parameters.Add("@Description", clientInformation.Description);
                    parameters.Add("@UpdatedDate", clientInformation.UpdatedDate);
                    parameters.Add("@UpdatedBy", clientInformation.UpdatedBy);

                    int rowsAffected = await connection.ExecuteAsync("UpdateClientInformation", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Updated ClientInformation with Id: {Id}. Rows affected: {RowsAffected}", clientInformation.Id, rowsAffected);
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error updating ClientInformation with Id: {Id}.", clientInformation.Id);
                throw;
            }
        }

        public async Task<int> DeleteClientInformationAsync(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);

                    int rowsAffected = await connection.ExecuteAsync("DeleteClientInformation", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Deleted ClientInformation with Id: {Id}. Rows affected: {RowsAffected}", id, rowsAffected);
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error deleting ClientInformation with Id: {Id}.", id);
                throw;
            }
        }

        public async Task<IEnumerable<ClientInformation>> GetClientInformationAsync(int pageNumber, int pageSize)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@PageNumber", pageNumber);
                    parameters.Add("@PageSize", pageSize);

                    var result = await connection.QueryAsync<ClientInformation>("GetAllClientInformations", parameters, commandType: CommandType.StoredProcedure);
                    _logger.LogInformation("Retrieved {Count} ClientInformation records for page {PageNumber} with page size {PageSize}.", result.AsList().Count, pageNumber, pageSize);
                    return result;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error retrieving ClientInformation records for page {PageNumber} with page size {PageSize}.", pageNumber, pageSize);
                throw;
            }
        }

        public async Task<ClientInformation> UpsertClientInformationAsync(ClientInformation clientInformation)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@AlphabetId", clientInformation.AlphabetId);
                    parameters.Add("@Name", clientInformation.Name);
                    parameters.Add("@Description", clientInformation.Description);
                    parameters.Add("@CreatedDate", clientInformation.CreatedDate);
                    parameters.Add("@UpdatedDate", clientInformation.UpdatedDate);
                    parameters.Add("@CreatedBy", clientInformation.CreatedBy);
                    parameters.Add("@UpdatedBy", clientInformation.UpdatedBy);

                    var query = "dbo.UpSertClientInformation";
                    var data = await connection.QueryFirstOrDefaultAsync<ClientInformation>(query, parameters, commandType: CommandType.StoredProcedure);
                    if (data != null)
                    {
                        _logger.LogInformation("UpSerted ClientInformation with AlphabetId: {AlphabetId}.", clientInformation.AlphabetId);
                    }
                    else
                    {
                        _logger.LogWarning("No ClientInformation returned after UpSert with AlphabetId: {AlphabetId}.", clientInformation.AlphabetId);
                    }
                    return data;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error UpSerting ClientInformation with AlphabetId: {AlphabetId}.", clientInformation.AlphabetId);
                throw;
            }
        }
    }
}