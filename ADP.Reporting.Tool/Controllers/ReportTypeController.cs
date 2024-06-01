using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> InsertReportType([FromBody] ReportType reportType)
        {
            var result = await _reportTypeService.InsertReportTypeAsync(reportType);
            if (result > 0)
                return Ok(result);

            return BadRequest("Insert failed.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReportType([FromBody] ReportType reportType)
        {
            var result = await _reportTypeService.UpdateReportTypeAsync(reportType);
            if (result > 0)
                return Ok(result);

            return BadRequest("Update failed.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportType(int id)
        {
            var result = await _reportTypeService.DeleteReportTypeAsync(id);
            if (result > 0)
                return Ok(result);

            return BadRequest("Delete failed.");
        }

        [HttpGet]
        public async Task<IActionResult> GetReportTypes(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _reportTypeService.GetReportTypesAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportTypeById(int id)
        {
            var result = await _reportTypeService.GetReportTypeByIdAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound("ReportType not found.");
        }
    }
}
