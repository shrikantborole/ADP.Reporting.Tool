using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> InsertRequestInformation([FromBody] RequestInformation requestInformation)
        {
            var result = await _requestInformationService.InsertRequestInformationAsync(requestInformation);
            if (result > 0)
                return Ok(result);

            return BadRequest("Insert failed.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRequestInformation([FromBody] RequestInformation requestInformation)
        {
            var result = await _requestInformationService.UpdateRequestInformationAsync(requestInformation);
            if (result > 0)
                return Ok(result);

            return BadRequest("Update failed.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestInformation(int id)
        {
            var result = await _requestInformationService.DeleteRequestInformationAsync(id);
            if (result > 0)
                return Ok(result);

            return BadRequest("Delete failed.");
        }

        [HttpGet]
        public async Task<IActionResult> GetRequestInformations(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _requestInformationService.GetRequestInformationsAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestInformationById(int id)
        {
            var result = await _requestInformationService.GetRequestInformationByIdAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound("RequestInformation not found.");
        }
    }
}
