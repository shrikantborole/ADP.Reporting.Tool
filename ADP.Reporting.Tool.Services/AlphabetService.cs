using ADP.Reporting.Tool.DataServices;
using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADP.Reporting.Tool.Services
{
    /// <summary>
    /// Provides services for managing Alphabet entities.
    /// </summary>
    public class AlphabetService : IAlphabetService
    {
        private readonly IAlphabetRepository _alphabetRepository;
        private readonly ILogger<AlphabetService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlphabetService"/> class.
        /// </summary>
        /// <param name="alphabetRepository">The repository used for alphabet data operations.</param>
        /// <param name="logger">The logger used for logging information and errors.</param>
        public AlphabetService(IAlphabetRepository alphabetRepository, ILogger<AlphabetService> logger)
        {
            _alphabetRepository = alphabetRepository;
            _logger = logger;
        }

        /// <summary>
        /// Deletes an Alphabet entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the Alphabet entity to delete.</param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while deleting the Alphabet entity.</exception>
        public async Task<int> DeleteAlphabetAsync(int id)
        {
            try
            {
                return await _alphabetRepository.DeleteAlphabetAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting Alphabet with ID {id}");
                throw;
            }
        }

        /// <summary>
        /// Retrieves all Alphabet entities with pagination.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A collection of Alphabet entities.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while retrieving the Alphabet entities.</exception>
        public async Task<IEnumerable<Alphabet>> GetAllAlphabetsAsync(int pageNumber, int pageSize)
        {
            try
            {
                return await _alphabetRepository.GetAllAlphabetsAsync(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all Alphabets");
                throw;
            }
        }

        /// <summary>
        /// Retrieves an Alphabet entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the Alphabet entity to retrieve.</param>
        /// <returns>The Alphabet entity if found; otherwise, null.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while retrieving the Alphabet entity.</exception>
        public async Task<Alphabet> GetAlphabetByIdAsync(int id)
        {
            try
            {
                return await _alphabetRepository.GetAlphabetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving Alphabet with ID {id}");
                throw;
            }
        }

        /// <summary>
        /// Inserts a new Alphabet entity.
        /// </summary>
        /// <param name="alphabet">The Alphabet entity to insert.</param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while inserting the Alphabet entity.</exception>
        public async Task<int> InsertAlphabetAsync(Alphabet alphabet)
        {
            try
            {
                alphabet.UpdatedDate = alphabet.UpdatedDate ?? DateTime.Now;
                alphabet.CreatedDate = alphabet.CreatedDate ?? DateTime.Now;
                return await _alphabetRepository.InsertAlphabetAsync(alphabet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while inserting a new Alphabet");
                throw;
            }
        }

        /// <summary>
        /// Updates an existing Alphabet entity.
        /// </summary>
        /// <param name="alphabet">The Alphabet entity to update.</param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while updating the Alphabet entity.</exception>
        public async Task<int> UpdateAlphabetAsync(Alphabet alphabet)
        {
            try
            {
                alphabet.UpdatedDate = DateTime.Now;
                return await _alphabetRepository.UpdateAlphabetAsync(alphabet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Alphabet with ID {alphabet.Id}");
                throw;
            }
        }

        /// <summary>
        /// Inserts or updates an Alphabet entity.
        /// </summary>
        /// <param name="alphabet">The Alphabet entity to insert or update.</param>
        /// <returns>The updated or inserted Alphabet entity.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while inserting or updating the Alphabet entity.</exception>
        public async Task<Alphabet> UpSertAlphabetAsync(Alphabet alphabet)
        {
            try
            {
                return await _alphabetRepository.UpsertAlphabetAsync(alphabet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while inserting or updating Alphabet with ID {alphabet.Id}");
                throw;
            }
        }
    }
}
