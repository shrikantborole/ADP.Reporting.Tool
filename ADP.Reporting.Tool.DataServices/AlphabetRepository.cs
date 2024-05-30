using ADP.Reporting.Tool.DataServices;
using ADP.Reporting.Tool.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

public class AlphabetRepository : IAlphabetRepository
{
    private readonly string _connectionString;

    public AlphabetRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<Alphabet>> GetAllAlphabetsAsync(int pageNumber, int pageSize)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", pageNumber);
            parameters.Add("@PageSize", pageSize);

            var query = "GetAllAlphabets";
            return await connection.QueryAsync<Alphabet>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}