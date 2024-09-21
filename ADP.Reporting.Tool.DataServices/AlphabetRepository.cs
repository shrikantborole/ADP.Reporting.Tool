using ADP.Reporting.Tool.DataServices;
using ADP.Reporting.Tool.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

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
                int rowsAffected = await connection.ExecuteAsync(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
                _logger.LogInformation("Deleted alphabet with ID {Id}. Rows affected: {RowsAffected}", id, rowsAffected);
                return rowsAffected;
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
                var alphabets = await connection.QueryAsync<Alphabet>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
                _logger.LogInformation("Retrieved {Count} alphabets for page {PageNumber} with size {PageSize}", alphabets.AsList().Count, pageNumber, pageSize);
                return alphabets;
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
                var alphabet = await connection.QueryFirstOrDefaultAsync<Alphabet>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (alphabet != null)
                {
                    _logger.LogInformation("Retrieved alphabet with ID {Id}", id);
                }
                else
                {
                    _logger.LogWarning("No alphabet found with ID {Id}", id);
                }
                return alphabet;
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
                int rowsAffected = await connection.ExecuteAsync(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
                _logger.LogInformation("Inserted alphabet with Name {AlphabetName}. Rows affected: {RowsAffected}", alphabet.Name, rowsAffected);
                return rowsAffected;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while inserting an alphabet with Name {AlphabetName}", alphabet.Name);
            throw;
        }
    }

    public async Task<Alphabet> UpsertAlphabetAsync(Alphabet alphabet)
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
                var result = await connection.QueryFirstOrDefaultAsync<Alphabet>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (result != null)
                {
                    _logger.LogInformation("UpSerted alphabet with Name {AlphabetName}", alphabet.Name);
                }
                else
                {
                    _logger.LogWarning("No alphabet returned after UpSert with Name {AlphabetName}", alphabet.Name);
                }
                return result;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while UpSerting an alphabet with Name {AlphabetName}", alphabet.Name);
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
                int rowsAffected = await connection.ExecuteAsync(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
                _logger.LogInformation("Updated alphabet with ID {Id}. Rows affected: {RowsAffected}", alphabet.Id, rowsAffected);
                return rowsAffected;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating the alphabet with ID {Id}", alphabet.Id);
            throw;
        }
    }
}
