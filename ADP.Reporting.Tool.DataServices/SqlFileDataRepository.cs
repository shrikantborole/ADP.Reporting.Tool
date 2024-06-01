using ADP.Reporting.Tool.DataServices.Interface;
using ADP.Reporting.Tool.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADP.Reporting.Tool.DataServices
{
    public class SqlFileDataRepository : ISqlFileDataRepository
    {
        private readonly string _connectionString;

        public SqlFileDataRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> InsertSqlFileDataAsync(SqlFileData sqlFileData)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RequestId", sqlFileData.RequestId);
                parameters.Add("@Description", sqlFileData.Description);
                parameters.Add("@SqlFileData", sqlFileData.SqlFileDataContent);
                parameters.Add("@CreatedDate", sqlFileData.CreatedDate);
                parameters.Add("@UpdatedDate", sqlFileData.UpdatedDate);
                parameters.Add("@CreatedBy", sqlFileData.CreatedBy);
                parameters.Add("@UpdatedBy", sqlFileData.UpdatedBy);

                return await db.ExecuteAsync("InsertSqlFileData", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateSqlFileDataAsync(SqlFileData sqlFileData)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", sqlFileData.Id);
                parameters.Add("@RequestId", sqlFileData.RequestId);
                parameters.Add("@Description", sqlFileData.Description);
                parameters.Add("@SqlFileData", sqlFileData.SqlFileDataContent);
                parameters.Add("@UpdatedDate", sqlFileData.UpdatedDate);
                parameters.Add("@UpdatedBy", sqlFileData.UpdatedBy);

                return await db.ExecuteAsync("UpdateSqlFileData", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> DeleteSqlFileDataAsync(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                return await db.ExecuteAsync("DeleteSqlFileData", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<SqlFileData>> GetSqlFileDatasAsync(int pageNumber, int pageSize)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", pageNumber);
                parameters.Add("@PageSize", pageSize);

                return await db.QueryAsync<SqlFileData>("GetAllSqlFileDatas", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<SqlFileData> GetSqlFileDataByIdAsync(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                return await db.QuerySingleOrDefaultAsync<SqlFileData>("GetSqlFileDataById", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
