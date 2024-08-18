using ADP.Reporting.Tool.DataServices.Interface;
using ADP.Reporting.Tool.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADP.Reporting.Tool.DataServices
{
    public class RequestInformationRepository : IRequestInformationRepository
    {
        private readonly string _connectionString;

        public RequestInformationRepository(IConfiguration configuration)
        {
            _connectionString =  configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> InsertRequestInformationAsync(RequestInformation requestInformation)
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

                return await db.ExecuteAsync("InsertRequestInformation", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateRequestInformationAsync(RequestInformation requestInformation)
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

                return await db.ExecuteAsync("UpdateRequestInformation", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> DeleteRequestInformationAsync(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                return await db.ExecuteAsync("DeleteRequestInformation", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<RequestInformation>> GetRequestInformationsAsync(int pageIndex, int pageSize)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", pageIndex);
                parameters.Add("@PageSize", pageSize);

                return await db.QueryAsync<RequestInformation>("GetAllRequestInformations", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<RequestInformation> GetRequestInformationByIdAsync(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                return await db.QuerySingleOrDefaultAsync<RequestInformation>("GetRequestInformationById", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<RequestInformation> UpSertRequestInformationAsync(RequestInformation requestInformation)
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

                return await db.QueryFirstOrDefaultAsync<RequestInformation>("UpSertRequestInformation", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
