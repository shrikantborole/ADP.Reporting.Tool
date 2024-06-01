using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> InsertSqlFileData([FromBody] SqlFileData sqlFileData)
        {
            var result = await _sqlFileDataService.InsertSqlFileDataAsync(sqlFileData);
            if (result > 0)
                return Ok(result);

            return BadRequest("Insert failed.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSqlFileData([FromBody] SqlFileData sqlFileData)
        {
            var result = await _sqlFileDataService.UpdateSqlFileDataAsync(sqlFileData);
            if (result > 0)
                return Ok(result);

            return BadRequest("Update failed.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSqlFileData(int id)
        {
            var result = await _sqlFileDataService.DeleteSqlFileDataAsync(id);
            if (result > 0)
                return Ok(result);

            return BadRequest("Delete failed.");
        }

        [HttpGet]
        public async Task<IActionResult> GetSqlFileDatas(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _sqlFileDataService.GetSqlFileDatasAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSqlFileDataById(int id)
        {
            var result = await _sqlFileDataService.GetSqlFileDataByIdAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound("SqlFileData not found.");
        }
    }
}
