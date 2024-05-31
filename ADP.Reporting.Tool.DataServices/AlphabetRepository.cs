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

    public async Task<bool> DeleteAlphabetAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var parameters = new { Id = id };
            var query = "DeleteAlphabet";
            var result = await connection.ExecuteAsync(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result > 0;
        }
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

    public async Task<Alphabet> GetAlphabetByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var parameters = new { Id = id };
            var query = "GetAlphabetById";
            return await connection.QueryFirstOrDefaultAsync<Alphabet>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }

    public async Task<Alphabet> InsertAlphabetAsync(Alphabet alphabet)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Alphabet", alphabet.Name);
            parameters.Add("@CreatedDate", alphabet.CreatedDate);
            parameters.Add("@UpdatedDate", alphabet.UpdatedDate);
            parameters.Add("@CreatedBy", alphabet.CreatedBy);
            parameters.Add("@UpdatedBy", alphabet.UpdatedBy);
            parameters.Add("@Description", alphabet.Description);

            var query = "InsertAlphabet";
            return await connection.QueryFirstOrDefaultAsync<Alphabet>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }

    public async Task<bool> UpdateAlphabetAsync(Alphabet alphabet)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", alphabet.Id);
            parameters.Add("@Alphabet", alphabet.Name);
            parameters.Add("@UpdatedDate", alphabet.UpdatedDate);
            parameters.Add("@UpdatedBy", alphabet.UpdatedBy);
            parameters.Add("@Description", alphabet.Description);

            var query = "UpdateAlphabet";
            var result = await connection.ExecuteAsync(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result > 0;
        }
    }
}