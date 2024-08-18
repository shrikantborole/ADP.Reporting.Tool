using ADP.Reporting.Tool.DataServices;
using ADP.Reporting.Tool.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

public class AlphabetRepository : IAlphabetRepository
{
    private readonly string _connectionString;
    private readonly ILogger<AlphabetRepository> _logger;

    public AlphabetRepository(IConfiguration configuration, ILogger<AlphabetRepository> logger)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _logger = logger;
    }

    public async Task<int> DeleteAlphabetAsync(int id)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new { Id = id };
                var query = "DeleteAlphabet";
                return await connection.ExecuteAsync(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting the alphabet with ID {Id}", id);
            throw;
        }
    }

    public async Task<IEnumerable<Alphabet>> GetAllAlphabetsAsync(int pageNumber, int pageSize)
    {
        try
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving alphabets for page {PageNumber} with size {PageSize}", pageNumber, pageSize);
            throw;
        }
    }

    public async Task<Alphabet> GetAlphabetByIdAsync(int id)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new { Id = id };
                var query = "GetAlphabetById";
                return await connection.QueryFirstOrDefaultAsync<Alphabet>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving the alphabet with ID {Id}", id);
            throw;
        }
    }

    public async Task<int> InsertAlphabetAsync(Alphabet alphabet)
    {
        try
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
                return await connection.ExecuteAsync(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while inserting an alphabet");
            throw;
        }
    }

    public async Task<Alphabet> UpSertAlphabetAsync(Alphabet alphabet)
    {
        try
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

                var query = "UpSertAlphabet";
                return await connection.QueryFirstOrDefaultAsync<Alphabet>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while inserting an alphabet");
            throw;
        }
    }

    public async Task<int> UpdateAlphabetAsync(Alphabet alphabet)
    {
        try
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
                return await connection.ExecuteAsync(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating the alphabet with ID {Id}", alphabet.Id);
            throw;
        }
    }
}