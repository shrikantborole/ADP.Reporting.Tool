using ADP.Reporting.Tool.DataServices.Interface;
using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADP.Reporting.Tool.Services
{
    /// <summary>
    /// Provides services for managing Client Information entities.
    /// </summary>
    public class ClientInformationService : IClientInformationService
    {
        private readonly IClientInformationRepository _clientInformationRepository;
        private readonly ILogger<ClientInformationService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientInformationService"/> class.
        /// </summary>
        /// <param name="clientInformationRepository">The repository used for client information data operations.</param>
        /// <param name="logger">The logger used for logging information and errors.</param>
        public ClientInformationService(IClientInformationRepository clientInformationRepository, ILogger<ClientInformationService> logger)
        {
            _clientInformationRepository = clientInformationRepository;
            _logger = logger;
        }

        /// <summary>
        /// Inserts a new Client Information entity.
        /// </summary>
        /// <param name="clientInformation">The Client Information entity to insert.</param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while inserting the Client Information entity.</exception>
        public async Task<int> InsertClientInformationAsync(ClientInformation clientInformation)
        {
            try
            {
                clientInformation.UpdatedDate = clientInformation.UpdatedDate ?? DateTime.Now;
                clientInformation.CreatedDate = clientInformation.CreatedDate ?? DateTime.Now;
                return await _clientInformationRepository.InsertClientInformationAsync(clientInformation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while inserting Client Information.");
                throw;
            }
        }

        /// <summary>
        /// Updates an existing Client Information entity.
        /// </summary>
        /// <param name="clientInformation">The Client Information entity to update.</param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while updating the Client Information entity.</exception>
        public async Task<int> UpdateClientInformationAsync(ClientInformation clientInformation)
        {
            try
            {
                clientInformation.UpdatedDate = DateTime.Now;
                return await _clientInformationRepository.UpdateClientInformationAsync(clientInformation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Client Information with ID {clientInformation.Id}");
                throw;
            }
        }

        /// <summary>
        /// Deletes a Client Information entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the Client Information entity to delete.</param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while deleting the Client Information entity.</exception>
        public async Task<int> DeleteClientInformationAsync(int id)
        {
            try
            {
                return await _clientInformationRepository.DeleteClientInformationAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting Client Information with ID {id}");
                throw;
            }
        }

        /// <summary>
        /// Retrieves all Client Information entities with pagination.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A collection of Client Information entities.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while retrieving the Client Information entities.</exception>
        public async Task<IEnumerable<ClientInformation>> GetClientInformationAsync(int pageNumber, int pageSize)
        {
            try
            {
                return await _clientInformationRepository.GetClientInformationAsync(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving Client Information.");
                throw;
            }
        }

        /// <summary>
        /// Inserts or updates a Client Information entity.
        /// </summary>
        /// <param name="clientInformation">The Client Information entity to insert or update.</param>
        /// <returns>The updated or inserted Client Information entity.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while inserting or updating the Client Information entity.</exception>
        public async Task<ClientInformation> UpSertClientInformationAsync(ClientInformation clientInformation)
        {
            try
            {
                return await _clientInformationRepository.UpsertClientInformationAsync(clientInformation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while inserting or updating Client Information with ID {clientInformation.Id}");
                throw;
            }
        }
    }
}
