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
    /// Service for handling operations related to request information.
    /// </summary>
    public class RequestInformationService : IRequestInformationService
    {
        private readonly IRequestInformationRepository _requestInformationRepository;
        private readonly ILogger<RequestInformationService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestInformationService"/> class.
        /// </summary>
        /// <param name="requestInformationRepository">The repository used for request information operations.</param>
        /// <param name="logger">The logger used for logging information and errors.</param>
        public RequestInformationService(IRequestInformationRepository requestInformationRepository, ILogger<RequestInformationService> logger)
        {
            _requestInformationRepository = requestInformationRepository;
            _logger = logger;
        }

        /// <summary>
        /// Inserts a new request information record.
        /// </summary>
        /// <param name="requestInformation">The request information to insert.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the ID of the inserted request information.</returns>
        public async Task<int> InsertRequestInformationAsync(RequestInformation requestInformation)
        {
            try
            {
                _logger.LogInformation($"Inserting request information with RequestId: {requestInformation.Id}");
                return await _requestInformationRepository.InsertRequestInformationAsync(requestInformation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while inserting request information with RequestId: {requestInformation.Id}");
                throw;
            }
        }

        /// <summary>
        /// Updates an existing request information record.
        /// </summary>
        /// <param name="requestInformation">The request information to update.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of affected rows.</returns>
        public async Task<int> UpdateRequestInformationAsync(RequestInformation requestInformation)
        {
            try
            {
                _logger.LogInformation($"Updating request information with ID: {requestInformation.Id}");
                return await _requestInformationRepository.UpdateRequestInformationAsync(requestInformation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating request information with ID: {requestInformation.Id}");
                throw;
            }
        }

        /// <summary>
        /// Deletes a request information record by its ID.
        /// </summary>
        /// <param name="id">The ID of the request information to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of affected rows.</returns>
        public async Task<int> DeleteRequestInformationAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting request information with ID: {id}");
                return await _requestInformationRepository.DeleteRequestInformationAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting request information with ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Retrieves a list of request information records with pagination.
        /// </summary>
        /// <param name="pageIndex">The page index for pagination.</param>
        /// <param name="pageSize">The page size for pagination.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable list of request information records.</returns>
        public async Task<IEnumerable<RequestInformation>> GetRequestInformationsAsync(int pageIndex, int pageSize)
        {
            try
            {
                _logger.LogInformation($"Retrieving request information with page index: {pageIndex} and page size: {pageSize}");
                return await _requestInformationRepository.GetRequestInformationsAsync(pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving request information with page index: {pageIndex} and page size: {pageSize}");
                throw;
            }
        }

        /// <summary>
        /// Retrieves a request information record by its ID.
        /// </summary>
        /// <param name="id">The ID of the request information to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the request information with the specified ID.</returns>
        public async Task<RequestInformation> GetRequestInformationByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Retrieving request information with ID: {id}");
                return await _requestInformationRepository.GetRequestInformationByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving request information with ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Inserts or updates a request information record.
        /// </summary>
        /// <param name="requestInformation">The request information to insert or update.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the inserted or updated request information.</returns>
        public async Task<RequestInformation> UpSertRequestInformationAsync(RequestInformation requestInformation)
        {
            try
            {
                _logger.LogInformation($"UpSerting request information with RequestId: {requestInformation.Id}");
                return await _requestInformationRepository.UpsertRequestInformationAsync(requestInformation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while upserting request information with RequestId: {requestInformation.Id}");
                throw;
            }
        }
    }
}
