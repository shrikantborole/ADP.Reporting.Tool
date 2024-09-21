using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ADP.Reporting.Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportTypeController : ControllerBase
    {
        private readonly IReportTypeService _reportTypeService;

        public ReportTypeController(IReportTypeService reportTypeService)
        {
            _reportTypeService = reportTypeService;
        }

        /// <summary>
        /// Inserts a new ReportType.
        /// </summary>
        /// <param name="reportType">The ReportType object to insert.</param>
        /// <returns>The ID of the inserted record.</returns>
        [HttpPost]
        public async Task<IActionResult> InsertReportType([FromBody][Required] ReportType reportType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _reportTypeService.InsertReportTypeAsync(reportType);
                if (result > 0)
                    return CreatedAtAction(nameof(GetReportTypeById), new { id = result }, reportType);

                return BadRequest("Insert failed.");
            }
            catch (Exception ex)
            {
                // Log the exception (add logging service)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing ReportType.
        /// </summary>
        /// <param name="reportType">The ReportType object to update.</param>
        /// <returns>Result of the update operation.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateReportType([FromBody][Required] ReportType reportType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _reportTypeService.UpdateReportTypeAsync(reportType);
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
        /// Deletes a ReportType by ID.
        /// </summary>
        /// <param name="id">The ID of the ReportType to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportType([FromRoute] int id)
        {
            try
            {
                var result = await _reportTypeService.DeleteReportTypeAsync(id);
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
        /// Gets a paginated list of ReportTypes.
        /// </summary>
        /// <param name="pageNumber">Page number for pagination.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <returns>A list of ReportTypes.</returns>
        [HttpGet]
        public async Task<IActionResult> GetReportTypes([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _reportTypeService.GetReportTypesAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (add logging service)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a ReportType by ID.
        /// </summary>
        /// <param name="id">The ID of the ReportType to retrieve.</param>
        /// <returns>The ReportType with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportTypeById([FromRoute] int id)
        {
            try
            {
                var result = await _reportTypeService.GetReportTypeByIdAsync(id);
                if (result != null)
                    return Ok(result);

                return NotFound("ReportType not found.");
            }
            catch (Exception ex)
            {
                // Log the exception (add logging service)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
