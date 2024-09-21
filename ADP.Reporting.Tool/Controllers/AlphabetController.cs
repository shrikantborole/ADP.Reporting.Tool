using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ADP.Reporting.Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlphabetController : ControllerBase
    {
        private readonly IAlphabetService _alphabetService;
        private readonly ILogger<AlphabetController> _logger;

        public AlphabetController(IAlphabetService alphabetService, ILogger<AlphabetController> logger)
        {
            _alphabetService = alphabetService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a paginated list of alphabets.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <param name="pageSize">The number of records per page.</param>
        /// <returns>A list of alphabets.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alphabet>>> GetAllAlphabets(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var alphabets = await _alphabetService.GetAllAlphabetsAsync(pageNumber, pageSize);
                return Ok(alphabets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving alphabets.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Retrieves an alphabet by its ID.
        /// </summary>
        /// <param name="id">The ID of the alphabet to retrieve.</param>
        /// <returns>The alphabet with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Alphabet>> GetAlphabetById(int id)
        {
            try
            {
                var alphabet = await _alphabetService.GetAlphabetByIdAsync(id);
                if (alphabet == null)
                {
                    return NotFound($"Alphabet with ID {id} not found.");
                }
                return Ok(alphabet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the alphabet with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Inserts a new alphabet.
        /// </summary>
        /// <param name="alphabet">The alphabet to insert.</param>
        /// <returns>HTTP status code indicating the result of the operation.</returns>
        [HttpPost]
        public async Task<ActionResult> InsertAlphabet([FromBody] Alphabet alphabet)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid.");
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _alphabetService.InsertAlphabetAsync(alphabet);
                if (result > 0)
                {
                    _logger.LogInformation("Alphabet inserted successfully.");
                    return Ok(result);
                }
                return BadRequest("Insert failed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting the alphabet.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Updates an existing alphabet.
        /// </summary>
        /// <param name="id">The ID of the alphabet to update.</param>
        /// <param name="alphabet">The updated alphabet data.</param>
        /// <returns>HTTP status code indicating the result of the operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlphabet(int id, [FromBody] Alphabet alphabet)
        {
            if (id != alphabet.Id)
            {
                _logger.LogWarning("ID mismatch in update request.");
                return BadRequest("ID mismatch.");
            }

            try
            {
                var result = await _alphabetService.UpdateAlphabetAsync(alphabet);
                if (result > 0)
                {
                    _logger.LogInformation("Alphabet updated successfully.");
                    return Ok(result);
                }
                return BadRequest("Update failed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the alphabet with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Deletes an alphabet by its ID.
        /// </summary>
        /// <param name="id">The ID of the alphabet to delete.</param>
        /// <returns>HTTP status code indicating the result of the operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlphabet(int id)
        {
            try
            {
                var result = await _alphabetService.DeleteAlphabetAsync(id);
                if (result > 0)
                {
                    _logger.LogInformation("Alphabet with ID {Id} deleted successfully.", id);
                    return Ok(result);
                }
                return BadRequest("Delete failed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the alphabet with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}