using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ADP.Reporting.Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientInformationController : ControllerBase
    {
        private readonly IClientInformationService _clientInformationService;

        public ClientInformationController(IClientInformationService clientInformationService)
        {
            _clientInformationService = clientInformationService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertClientInformation([FromBody] ClientInformation clientInformation)
        {
            var result = await _clientInformationService.InsertClientInformationAsync(clientInformation);
            if (result > 0)
                return Ok(result);

            return BadRequest("Insert failed.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClientInformation([FromBody] ClientInformation clientInformation)
        {
            var result = await _clientInformationService.UpdateClientInformationAsync(clientInformation);
            if (result > 0)
                return Ok(result);

            return BadRequest("Update failed.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientInformation(int id)
        {
            var result = await _clientInformationService.DeleteClientInformationAsync(id);
            if (result > 0)
                return Ok(result);

            return BadRequest("Delete failed.");
        }

        [HttpGet]
        public async Task<IActionResult> GetClientInformation(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _clientInformationService.GetClientInformationAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost("upsert")]
        public async Task<IActionResult> UpSertClientInformation([FromBody] ClientInformation clientInformation)
        {
            var result = await _clientInformationService.UpSertClientInformationAsync(clientInformation);
            return Ok(result);
        }
    }
}
