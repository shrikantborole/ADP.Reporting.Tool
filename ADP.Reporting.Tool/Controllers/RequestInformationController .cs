using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ADP.Reporting.Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestInformationController : ControllerBase
    {
        private readonly IRequestInformationService _requestInformationService;

        public RequestInformationController(IRequestInformationService requestInformationService)
        {
            _requestInformationService = requestInformationService;
        }

        /// <summary>
        /// Inserts new RequestInformation.
        /// </summary>
        /// <param name="requestInformation">The RequestInformation object to insert.</param>
        /// <returns>The ID of the inserted record.</returns>
        [HttpPost]
        public async Task<IActionResult> InsertRequestInformation([FromBody][Required] RequestInformation requestInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _requestInformationService.InsertRequestInformationAsync(requestInformation);
                if (result > 0)
                    return CreatedAtAction(nameof(GetRequestInformationById), new { id = result }, requestInformation);

                return BadRequest("Insert failed.");
            }
            catch (Exception ex)
            {
                // Log the exception (add logging service)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates existing RequestInformation.
        /// </summary>
        /// <param name="requestInformation">The RequestInformation object to update.</param>
        /// <returns>Result of the update operation.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateRequestInformation([FromBody][Required] RequestInformation requestInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _requestInformationService.UpdateRequestInformationAsync(requestInformation);
                if (result > 0)
                    return Ok(result);

                return BadRequest("Update failed.");
            }
            catch (Exception ex)
            {
                // Log the exception (add logging service)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes RequestInformation by ID.
        /// </summary>
        /// <param name="id">The ID of the RequestInformation to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestInformation([FromRoute] int id)
        {
            try
            {
                var result = await _requestInformationService.DeleteRequestInformationAsync(id);
                if (result > 0)
                    return Ok(result);

                return BadRequest("Delete failed.");
            }
            catch (Exception ex)
            {
                // Log the exception (add logging service)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a paginated list of RequestInformations.
        /// </summary>
        /// <param name="pageNumber">Page number for pagination.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <returns>A list of RequestInformation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetRequestInformations([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _requestInformationService.GetRequestInformationsAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (add logging service)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets RequestInformation by ID.
        /// </summary>
        /// <param name="id">The ID of the RequestInformation to retrieve.</param>
        /// <returns>The RequestInformation with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestInformationById([FromRoute] int id)
        {
            try
            {
                var result = await _requestInformationService.GetRequestInformationByIdAsync(id);
                if (result != null)
                    return Ok(result);

                return NotFound("RequestInformation not found.");
            }
            catch (Exception ex)
            {
                // Log the exception (add logging service)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
