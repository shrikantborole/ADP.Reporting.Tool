using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ADP.Reporting.Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlFileDataController : ControllerBase
    {
        private readonly ISqlFileDataService _sqlFileDataService;

        public SqlFileDataController(ISqlFileDataService sqlFileDataService)
        {
            _sqlFileDataService = sqlFileDataService;
        }

        /// <summary>
        /// Inserts new SqlFileData.
        /// </summary>
        /// <param name="sqlFileData">The SqlFileData object to insert.</param>
        /// <returns>The ID of the inserted record.</returns>
        [HttpPost]
        public async Task<IActionResult> InsertSqlFileData([FromBody][Required] SqlFileData sqlFileData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _sqlFileDataService.InsertSqlFileDataAsync(sqlFileData);
                if (result > 0)
                    return CreatedAtAction(nameof(GetSqlFileDataById), new { id = result }, sqlFileData);

                return BadRequest("Insert failed.");
            }
            catch (Exception ex)
            {
                // Log the exception (add logging service)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates existing SqlFileData.
        /// </summary>
        /// <param name="sqlFileData">The SqlFileData object to update.</param>
        /// <returns>Result of the update operation.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateSqlFileData([FromBody][Required] SqlFileData sqlFileData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _sqlFileDataService.UpdateSqlFileDataAsync(sqlFileData);
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
        /// Deletes SqlFileData by ID.
        /// </summary>
        /// <param name="id">The ID of the SqlFileData to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSqlFileData([FromRoute] int id)
        {
            try
            {
                var result = await _sqlFileDataService.DeleteSqlFileDataAsync(id);
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
        /// Gets a paginated list of SqlFileDatas.
        /// </summary>
        /// <param name="pageNumber">Page number for pagination.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <returns>A list of SqlFileData.</returns>
        [HttpGet]
        public async Task<IActionResult> GetSqlFileDatas([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _sqlFileDataService.GetSqlFileDatasAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (add logging service)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets SqlFileData by ID.
        /// </summary>
        /// <param name="id">The ID of the SqlFileData to retrieve.</param>
        /// <returns>The SqlFileData with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSqlFileDataById([FromRoute] int id)
        {
            try
            {
                var result = await _sqlFileDataService.GetSqlFileDataByIdAsync(id);
                if (result != null)
                    return Ok(result);

                return NotFound("SqlFileData not found.");
            }
            catch (Exception ex)
            {
                // Log the exception (add logging service)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
