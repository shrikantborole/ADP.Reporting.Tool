using ADP.Reporting.Tool.DataServices.Interface;
using ADP.Reporting.Tool.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADP.Reporting.Tool.DataServices
{
    public class ClientInformationRepository :IClientInformationRepository
    {
        private readonly string _connectionString;

        public ClientInformationRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> InsertClientInformationAsync(ClientInformation clientInformation)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AlphabetId", clientInformation.AlphabetId);
                parameters.Add("@Name", clientInformation.Name);
                parameters.Add("@Description", clientInformation.Description);
                parameters.Add("@CreatedDate", clientInformation.CreatedDate);
                parameters.Add("@UpdatedDate", clientInformation.UpdatedDate);
                parameters.Add("@CreatedBy", clientInformation.CreatedBy);
                parameters.Add("@UpdatedBy", clientInformation.UpdatedBy);

                return await db.ExecuteAsync("InsertClientInformation", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateClientInformationAsync(ClientInformation clientInformation)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", clientInformation.Id);
                parameters.Add("@AlphabetId", clientInformation.AlphabetId);
                parameters.Add("@Name", clientInformation.Name);
                parameters.Add("@Description", clientInformation.Description);
                parameters.Add("@UpdatedDate", clientInformation.UpdatedDate);
                parameters.Add("@UpdatedBy", clientInformation.UpdatedBy);

                return await db.ExecuteAsync("UpdateClientInformation", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> DeleteClientInformationAsync(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                return await db.ExecuteAsync("DeleteClientInformation", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ClientInformation>> GetClientInformationAsync(int pageNumber, int pageSize)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", pageNumber);
                parameters.Add("@PageSize", pageSize);

                return await db.QueryAsync<ClientInformation>("GetAllClientInformations", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
