using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services;
using Microsoft.AspNetCore.Mvc;

namespace ADP.Reporting.Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlphabetController : ControllerBase
    {
        private readonly IAlphabetService alphabetService;
        private readonly ILogger<AlphabetController> logger;
        public AlphabetController(IAlphabetService alphabetService, ILogger<AlphabetController> logger)
        {
            this.alphabetService = alphabetService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alphabet>>> GetAllAlphabets(int pageNumber = 1, int pageSize = 10)
        {
            var alphabets = await alphabetService.GetAllAlphabetsAsync(pageNumber, pageSize);
            return Ok(alphabets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alphabet>> GetAlphabetById(int id)
        {
            var alphabet = await alphabetService.GetAlphabetByIdAsync(id);
            if (alphabet == null)
            {
                return NotFound();
            }
            return Ok(alphabet);
        }

        [HttpPost]
        public async Task<ActionResult> InsertAlphabet([FromBody] Alphabet alphabet)
        {
            if (!ModelState.IsValid)
            {
                // Log or inspect the ModelState errors
                return BadRequest(ModelState);
            }
            var result = await alphabetService.InsertAlphabetAsync(alphabet);
            if (result > 0)
                return Ok(result);

            return BadRequest("Insert failed.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlphabet(int id, [FromBody] Alphabet alphabet)
        {
            if (id != alphabet.Id)
            {
                return BadRequest();
            }

            var result = await alphabetService.UpdateAlphabetAsync(alphabet);
            if (result > 0)
                return Ok(result);

            return BadRequest("Update failed.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlphabet(int id)
        {
            var result = await alphabetService.DeleteAlphabetAsync(id);
            if (result > 0)
                return Ok(result);

            return BadRequest("Delete failed.");
        }
    }
}
