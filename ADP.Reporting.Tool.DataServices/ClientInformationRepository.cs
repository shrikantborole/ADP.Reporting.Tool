using ADP.Reporting.Tool.DataServices.Interface;
using ADP.Reporting.Tool.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADP.Reporting.Tool.DataServices
{
    public class ClientInformationRepository : IClientInformationRepository
    {
        private readonly string _connectionString;

        public ClientInformationRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> InsertClientInformationAsync(ClientInformation clientInformation)
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

                return await connection.ExecuteAsync("InsertClientInformation", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateClientInformationAsync(ClientInformation clientInformation)
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

                return await connection.ExecuteAsync("UpdateClientInformation", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> DeleteClientInformationAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                return await connection.ExecuteAsync("DeleteClientInformation", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ClientInformation>> GetClientInformationAsync(int pageNumber, int pageSize)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", pageNumber);
                parameters.Add("@PageSize", pageSize);

                return await connection.QueryAsync<ClientInformation>("GetAllClientInformations", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<ClientInformation> UpSertClientInformationAsync(ClientInformation clientInformation)
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
                    var data = await connection.QueryFirstOrDefaultAsync<ClientInformation>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    return data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
