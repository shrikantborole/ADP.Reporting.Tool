using ADP.Reporting.Tool.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using ADP.Reporting.Tool.DataServices.Interface;

namespace ADP.Reporting.Tool.DataServices
{
    public class ReportTypeRepository : IReportTypeRepository
    {
        private readonly string _connectionString;

        public ReportTypeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> InsertReportTypeAsync(ReportType reportType)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ClientId", reportType.ClientId);
                parameters.Add("@Type", reportType.Type);
                parameters.Add("@Description", reportType.Description);
                parameters.Add("@CreatedDate", reportType.CreatedDate);
                parameters.Add("@UpdatedDate", reportType.UpdatedDate);
                parameters.Add("@CreatedBy", reportType.CreatedBy);
                parameters.Add("@UpdatedBy", reportType.UpdatedBy);

                return await db.ExecuteAsync("InsertReportType", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateReportTypeAsync(ReportType reportType)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", reportType.Id);
                parameters.Add("@ClientId", reportType.ClientId);
                parameters.Add("@Type", reportType.Type);
                parameters.Add("@Description", reportType.Description);
                parameters.Add("@UpdatedDate", reportType.UpdatedDate);
                parameters.Add("@UpdatedBy", reportType.UpdatedBy);

                return await db.ExecuteAsync("UpdateReportType", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> DeleteReportTypeAsync(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                return await db.ExecuteAsync("DeleteReportType", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ReportType>> GetReportTypesAsync(int pageIndex, int pageSize)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", pageIndex);
                parameters.Add("@PageSize", pageSize);

                return await db.QueryAsync<ReportType>("GetAllReportTypes", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<ReportType> GetReportTypeByIdAsync(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                return await db.QuerySingleOrDefaultAsync<ReportType>("GetReportTypeById", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}