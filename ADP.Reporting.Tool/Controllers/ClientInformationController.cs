using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ADP.Reporting.Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientInformationController : ControllerBase
    {
        private readonly IClientInformationService _clientInformationService;
        private readonly ILogger<ClientInformationController> _logger;

        public ClientInformationController(IClientInformationService clientInformationService, ILogger<ClientInformationController> logger)
        {
            _clientInformationService = clientInformationService;
            _logger = logger;
        }

        /// <summary>
        /// Inserts a new client information record.
        /// </summary>
        /// <param name="clientInformation">The client information to insert.</param>
        /// <returns>HTTP Status Code indicating the result of the operation.</returns>
        [HttpPost]
        public async Task<IActionResult> InsertClientInformation([FromBody] ClientInformation clientInformation)
        {
            try
            {
                var result = await _clientInformationService.InsertClientInformationAsync(clientInformation);
                if (result > 0)
                {
                    _logger.LogInformation("Client information inserted successfully.");
                    return Ok(result);
                }

                _logger.LogWarning("Insert client information failed.");
                return BadRequest("Insert failed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting client information.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Updates an existing client information record.
        /// </summary>
        /// <param name="clientInformation">The client information to update.</param>
        /// <returns>HTTP Status Code indicating the result of the operation.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateClientInformation([FromBody] ClientInformation clientInformation)
        {
            try
            {
                var result = await _clientInformationService.UpdateClientInformationAsync(clientInformation);
                if (result > 0)
                {
                    _logger.LogInformation("Client information updated successfully.");
                    return Ok(result);
                }

                _logger.LogWarning("Update client information failed.");
                return BadRequest("Update failed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating client information.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Deletes a client information record.
        /// </summary>
        /// <param name="id">The ID of the client information record to delete.</param>
        /// <returns>HTTP Status Code indicating the result of the operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientInformation(int id)
        {
            try
            {
                var result = await _clientInformationService.DeleteClientInformationAsync(id);
                if (result > 0)
                {
                    _logger.LogInformation("Client information with ID {Id} deleted successfully.", id);
                    return Ok(result);
                }

                _logger.LogWarning("Delete client information failed for ID {Id}.", id);
                return BadRequest("Delete failed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting client information with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Retrieves a paginated list of client information records.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <param name="pageSize">The number of records per page.</param>
        /// <returns>A paginated list of client information records.</returns>
        [HttpGet]
        public async Task<IActionResult> GetClientInformation(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var result = await _clientInformationService.GetClientInformationAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving client information.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Inserts or updates a client information record.
        /// </summary>
        /// <param name="clientInformation">The client information to insert or update.</param>
        /// <returns>HTTP Status Code indicating the result of the operation.</returns>
        [HttpPost("upsert")]
        public async Task<IActionResult> UpSertClientInformation([FromBody] ClientInformation clientInformation)
        {
            try
            {
                var result = await _clientInformationService.UpSertClientInformationAsync(clientInformation);
                if (result != null)
                {
                    _logger.LogInformation("Client information upserted successfully.");
                    return Ok(result);
                }

                _logger.LogWarning("Upsert client information failed.");
                return BadRequest("Upsert failed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while upserting client information.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
